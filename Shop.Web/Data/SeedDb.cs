using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    /// <summary>
    /// Clase que nos permite guardar registros a la DB si es que no contiene ningún registro.
    /// </summary>
    public class SeedDb
    {
        private readonly DataContext context;

        private Random random;


        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }


        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.Products.Any())
            {
                this.AddProduct("Iphone x");
                this.AddProduct("Magic Maouse");
                this.AddProduct("Iwatch Series 4");

                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {

            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(100),
                IsAvailabe = true,
                Stock = this.random.Next(100)
            }
                );
        }
    }
}
