﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Entities.Product> Products { get; set; }

        public DbSet<Entities.Country> Countries { get; set; }

        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }


    }
}
