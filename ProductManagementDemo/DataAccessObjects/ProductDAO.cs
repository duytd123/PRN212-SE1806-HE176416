using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> listProducts;
        private static readonly ILogger<ProductDAO> _logger;

        static ProductDAO()
        {
            // Initialize the static product list
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);
            Product chef = new Product(4, "Chef Anton's Cajun Seasoning", 2, 34, 22);
            Product chefMix = new Product(5, "Chef Anton's Gumbo Mix", 2, 45, 34);
            Product grandma = new Product(6, "Grandma's Boysenberry Spread", 2, 21, 25);
            Product uncle = new Product(7, "Uncle Bob's Organic Dried Pears", 7, 22, 30);
            Product northwoods = new Product(8, "Northwoods Cranberry Sauce", 2, 10, 40);
            Product mishi = new Product(9, "Mishi Kobe Niku", 6, 12, 97);
            Product ikura = new Product(10, "Ikura", 8, 13, 32);

            listProducts = new List<Product> { chai, chang, aniseed, chef, chefMix, grandma, uncle, northwoods, mishi, ikura };
        }

        public static List<Product> GetProduct()
        {
            return new List<Product>(listProducts);
        }

        public static List<Product> GetProducts()
        {
            var listProducts = new List<Product>();
            try
            {
                using var db = new MyStore();
                listProducts = db.Products.Include(p => p.Category).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving products from the database.");
            }

            return listProducts;
        }

        public static void SaveProduct(Product p)
        {
            try
            {
                using var db = new MyStore();
                db.Products.Add(p);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while saving the product to the database.");
            }
        }

        public static void UpdateProduct(Product product)
        {
            try
            {
                using var db = new MyStore();
                var existingProduct = db.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    existingProduct.ProductName = product.ProductName;
                    existingProduct.UnitPrice = product.UnitPrice;
                    existingProduct.UnitsInStock = product.UnitsInStock;
                    existingProduct.CategoryId = product.CategoryId;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while updating the product in the database.");
            }
        }

        public static void DeleteProduct(Product product)
        {
            try
            {
                using var db = new MyStore();
                var existingProduct = db.Products.Find(product.ProductId);
                if (existingProduct != null)
                {
                    db.Products.Remove(existingProduct);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while deleting the product from the database.");
            }
        }

        public static Product GetProductById(int id)
        {
            try
            {
                using var db = new MyStore();
                var product = db.Products.Find(id);
                if (product == null)
                {
                    throw new KeyNotFoundException($"Product with ID {id} not found.");
                }
                return product;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while retrieving the product by ID from the database.");
                throw;
            }
        }
    }
}


