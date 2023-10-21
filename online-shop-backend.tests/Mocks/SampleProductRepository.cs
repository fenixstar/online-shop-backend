using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleProductRepository : IProductRepository
    {
        public SampleProductRepository()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product1",
                    AvailableQuantity = 10,
                    Price = 15.5m,
                    CategoryId = 1,
                    Category = new Category
                    {
                        Id = 1,
                        Title = "Cat1"
                    },
                    SubcategoryId = 1,
                    Subcategory = new Subcategory
                    {
                        Id = 1,
                        Title = "Sub1",
                        CategoryId = 1
                    },
                    ProducerId = 1,
                    Producer = new Producer
                    {
                        Id = 1,
                        Name = "Producer1"
                    }
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    AvailableQuantity = 20,
                    Price = 25.5m,
                    CategoryId = 2,
                    Category = new Category
                    {
                        Id = 2,
                        Title = "Cat2"
                    },
                    SubcategoryId = 3,
                    Subcategory = new Subcategory
                    {
                        Id = 3,
                        Title = "Sub3",
                        CategoryId = 2
                    },
                    ProducerId = 2,
                    Producer = new Producer
                    {
                        Id = 2,
                        Name = "Producer2"
                    }
                }
            };
        }

        private ICollection<Product> Products { get; }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Products.Remove(product);
        }

        public void UpdateProduct(Product product)
        {
            Products.Remove(Products.First(p => p.Id == product.Id));
            Products.Add(product);
        }

        public Product GetProduct(long id)
        {
            return Products.First(p => p.Id == id);
        }

        public ICollection<Product> GetAllProducts()
        {
            return Products;
        }

        public Producer GetProducerForProduct(long id)
        {
            return Products.First(p => p.Id == id)?.Producer;
        }

        public Category GetCategoryForProduct(long id)
        {
            return Products.First(p => p.Id == id)?.Category;
        }

        public Subcategory GetSubcategoryForProduct(long id)
        {
            return Products.First(p => p.Id == id)?.Subcategory;
        }

        public ICollection<Review> GetReviewsForProduct(long id)
        {
            return Products.First(p => p.Id == id)?.Reviews;
        }

        public ICollection<Discount> GetDiscountsForProduct(long id)
        {
            return Products.First(p => p.Id == id)?.Discounts;
        }

        public bool CheckIfProductIsAvailable(long id, int neededQuantity = 0)
        {
            return Products.First(p => p.Id == id).AvailableQuantity >= neededQuantity;
        }
    }
}