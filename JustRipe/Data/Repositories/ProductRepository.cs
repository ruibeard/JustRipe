﻿using JustRipe.Data.DTOs;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JustRipe.Data.Repositories
{
    public class ProductRepository : SQLiteDb, IDisposable
    {
        private readonly IRepository<ProductDTO> productRepo;
        private readonly IRepository<CategoryDTO> categoryRepo;

        public ProductRepository(IRepository<ProductDTO> productRepo, IRepository<CategoryDTO> categoryRepo)
        {
            this.productRepo = productRepo;
            this.categoryRepo = categoryRepo;
        }

        public IEnumerable<Product> GetAllFertilizersProductsCurrentlyInStock()
        {
            return from product in productRepo.GetAll()
                   join cat in categoryRepo.GetAll() on product.CategoryId equals cat.Id
                   where product.Quantity > 0
                   where cat.Name is "Fertiliser"
                   select new Product()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       CategoryName = cat.Name,
                       Quantity = product.Quantity,
                       Unit = product.Unit,
                       Description = product.Description,
                       Price = product.Price,
                       Status = product.Status

                   };
        }

        public IEnumerable<Product> GetAllProductsCurrentlyInStock()
        {
            return from product in productRepo.GetAll()
                   join cat in categoryRepo.GetAll() on product.CategoryId equals cat.Id
                   where product.Quantity > 0
                   select new Product()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       CategoryName = cat.Name,
                       Quantity = product.Quantity,
                       Unit = product.Unit,
                       Description = product.Description,
                       Price = product.Price,
                       Status = product.Status

                   };
        }

        public IEnumerable<Product> GetAllFertiliserProducts()
        {
            return from product in productRepo.GetAll()
                   join cat in categoryRepo.GetAll() on product.CategoryId equals cat.Id
                   where cat.Name is "Fertiliser"
                   select new Product()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       CategoryName = cat.Name,
                       Quantity = product.Quantity,
                       Unit = product.Unit,
                       Description = product.Description,
                       Price = product.Price,
                       Status = product.Status
                   };
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return from product in productRepo.GetAll()
                   join cat in categoryRepo.GetAll() on product.CategoryId equals cat.Id
                   select new Product()
                   {
                       Id = product.Id,
                       Name = product.Name,
                       CategoryName = cat.Name,
                       Quantity = product.Quantity,
                       Unit = product.Unit,
                       Description = product.Description,
                       Price = product.Price,
                       Status= product.Status
                   };
        }

        public void UpdateProduct(ProductDTO _product)
        {
            productRepo.Update(_product);
        }
        public void DeleteProduct(ProductDTO _product)
        {
            productRepo.Delete(_product);
        }

        public void AddProduct(ProductDTO _product)
        {
            productRepo.Add(_product);
        }


        public void Dispose()
        {
            productRepo.Dispose();
        }
    }
}