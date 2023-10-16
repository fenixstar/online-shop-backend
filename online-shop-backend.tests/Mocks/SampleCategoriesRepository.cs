using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleCategoriesRepository : ICategoriesRepository
    {
        public SampleCategoriesRepository()
        {
            Categories = new List<Category>
            {
                new Category
                {
                    ID = 1,
                    Title = "Cat1",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            ID = 1,
                            CategoryID = 1,
                            Title = "Sub1"
                        },
                        new Subcategory
                        {
                            ID = 2,
                            CategoryID = 1,
                            Title = "Sub2"
                        }
                    }
                },
                new Category
                {
                    ID = 2,
                    Title = "Cat2",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            ID = 3,
                            CategoryID = 2,
                            Title = "Sub3"
                        },
                        new Subcategory
                        {
                            ID = 4,
                            CategoryID = 2,
                            Title = "Sub4"
                        }
                    }
                }
            };

            Products = new List<Product>
            {
                new Product
                {
                    ID = 1,
                    Name = "Product1",
                    AvailableQuantity = 10,
                    Price = 15.5m,
                    CategoryID = 1,
                    SubcategoryID = 1,
                    ProducerID = 1
                },
                new Product
                {
                    ID = 2,
                    Name = "Product2",
                    AvailableQuantity = 20,
                    Price = 25.5m,
                    CategoryID = 2,
                    SubcategoryID = 3,
                    ProducerID = 2
                }
            };
        }

        private ICollection<Category> Categories { get; }
        private ICollection<Product> Products { get; }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            Categories.Remove(Categories.First(cat => cat.ID == category.ID));
            Categories.Add(category);
        }

        public Category GetCategory(int id)
        {
            return Categories.First(cat => cat.ID == id);
        }

        public ICollection<Category> GetAllCategories()
        {
            return Categories;
        }

        public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
        {
            return Categories.First(cat => cat.ID == id)?.Subcategories;
        }

        public ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20)
        {
            return Products.Where(p => p.CategoryID == id).ToList();
        }
    }
}