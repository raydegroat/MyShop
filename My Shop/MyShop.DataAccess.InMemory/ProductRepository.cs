﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;
using System.Security.Cryptography.X509Certificates;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if(products == null)
            {
                products = new List<Product>();
            }
        }
        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }
        
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            
            if(productToUpdate != null)
            {
                productToUpdate = product;
            }else
            {
                throw new Exception("Prodcut not found");
            }
        }
        public Product Find(string Id)
        {
            Product product = products.Find(p => p.Id == Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }
        public void Delete(string Id)
        {
            Product prodcutToDelete = products.Find(p => p.Id == Id);

            if(prodcutToDelete != null)
            {
                products.Remove(prodcutToDelete);
            }
            else
            {
                throw new Exception("Prodcut not found");
            }
        }
    }
}
