using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleSubcategoriesRepository : ISubcategoriesRepository
    {
        public SampleSubcategoriesRepository()
        {
            Subcategories = new List<Subcategory>
            {
                new Subcategory
                {
                    Id = 1,
                    Title = "Sub1",
                    CategoryId = 1,
                    Category = new Category
                    {
                        Id = 1,
                        Title = "Cat1"
                    }
                },
                new Subcategory
                {
                    Id = 3,
                    Title = "Sub3",
                    CategoryId = 2,
                    Category = new Category
                    {
                        Id = 2,
                        Title = "Cat2"
                    }
                }
            };

            Products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Product1",
                    AvailableQuantity = 10,
                    Price = 15.5m,
                    CategoryId = 1,
                    SubcategoryId = 1,
                    ProducerId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Product2",
                    AvailableQuantity = 20,
                    Price = 25.5m,
                    CategoryId = 2,
                    SubcategoryId = 3,
                    ProducerId = 2
                }
            };
        }

        private ICollection<Subcategory> Subcategories { get; }
        private ICollection<Product> Products { get; }

        public void AddSubcategory(Subcategory subcategory)
        {
            Subcategories.Add(subcategory);
        }

        public void RemoveSubcategory(Subcategory subcategory)
        {
            Subcategories.Remove(subcategory);
        }

        public void UpdateSubcategory(Subcategory subcategory)
        {
            Subcategories.Remove(Subcategories.First(sub => sub.Id == subcategory.Id));
            Subcategories.Add(subcategory);
        }

        public Subcategory GetSubcategory(int id)
        {
            return Subcategories.First(sub => sub.Id == id);
        }

        public ICollection<Subcategory> GetAllSubcategories()
        {
            return Subcategories;
        }

        public Category GetCategoryForSubcategory(int id)
        {
            return Subcategories.First(sub => sub.Id == id)?.Category;
        }

        public ICollection<Product> GetProductsForSubcategory(int id, int page = 1, int limit = 20)
        {
            return Products.Where(p => p.SubcategoryId == id).ToList();
        }
    }
}