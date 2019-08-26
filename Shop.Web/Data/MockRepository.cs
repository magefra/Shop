﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class MockRepository : IRepository
    {
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product()
                {
                    Id = 1,
                    Name = "One",
                    Price = 100
                },
                 new Product()
                {
                    Id = 2,
                    Name = "Two",
                    Price = 8966
                },
                  new Product()
                {
                    Id = 3,
                    Name = "Three",
                    Price = 52
                }

            };

            return products;
        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
