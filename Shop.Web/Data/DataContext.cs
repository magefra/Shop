
using Microsoft.EntityFrameworkCore;


namespace Shop.Web.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Entities.Product> Products { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
        }


    }
}
