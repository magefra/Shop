namespace Shop.Web.Data
{
    using Microsoft.AspNetCore.Identity;
    using Shop.Web.Data.Entities;
    using Shop.Web.Helpers;
    using System;
    using System.Linq;
    using System.Threading.Tasks;


    /// <summary>
    /// Clase que nos permite guardar registros a la DB si es que no contiene ningún registro.
    /// </summary>
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            random = new Random();
        }


        public async Task SeedAsync()
        {
            await context.Database.EnsureCreatedAsync();


            var user = await userHelper.GetUserByMailAsync("magdiel.palacios@csfacturacion.com");

            if (user == null)
            {
                user = new User()
                {
                    FirstName = "Magdiel",
                    LastName = "Palacios",
                    Email = "magdiel.palacios@csfacturacion.com",
                    UserName = "magdiel.palacios@csfacturacion.com",
                    PhoneNumber = "2888893680"
                };


                var result = await userHelper.AddUserAsync(user, "123456");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

            }


            if (!context.Products.Any())
            {
                AddProduct("Iphone x", user);
                AddProduct("Magic Maouse", user);
                AddProduct("Iwatch Series 4", user);

                await context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {

            context.Products.Add(new Product
            {
                Name = name,
                Price = random.Next(100),
                IsAvailabe = true,
                Stock = random.Next(100),
                User = user
            }
                );
        }
    }
}
