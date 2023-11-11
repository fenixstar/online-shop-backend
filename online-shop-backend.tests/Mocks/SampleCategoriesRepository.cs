using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.DTO;
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
                    Id = 1,
                    Title = "Cat1",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            Id = 1,
                            CategoryId = 1,
                            Title = "Sub1"
                        },
                        new Subcategory
                        {
                            Id = 2,
                            CategoryId = 1,
                            Title = "Sub2"
                        }
                    }
                },
                new Category
                {
                    Id = 2,
                    Title = "Cat2",
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory
                        {
                            Id = 3,
                            CategoryId = 2,
                            Title = "Sub3"
                        },
                        new Subcategory
                        {
                            Id = 4,
                            CategoryId = 2,
                            Title = "Sub4"
                        }
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

        private ICollection<Category> Categories { get; }
        private ICollection<Product> Products { get; }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void AddCategory(CategoryDto category)
        {
            throw new System.NotImplementedException();
        }

        public void RemoveCategory(Category category)
        {
            Categories.Remove(category);
        }

        public void UpdateCategory(Category category)
        {
            Categories.Remove(Categories.First(cat => cat.Id == category.Id));
            Categories.Add(category);
        }

        public Category GetCategory(int id)
        {
            return Categories.First(cat => cat.Id == id);
        }

        public ICollection<Category> GetAllCategories()
        {
            return Categories;
        }

        public ICollection<Subcategory> GetSubcategoriesForCategory(int id)
        {
            return Categories.First(cat => cat.Id == id)?.Subcategories;
        }

        public ICollection<Product> GetProductsForCategory(int id, int page = 1, int limit = 20)
        {
            return Products.Where(p => p.CategoryId == id).ToList();
        }
    }
}