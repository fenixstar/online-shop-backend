using System;
using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleDiscountRepository : IDiscountRepository
    {
        public SampleDiscountRepository()
        {
            Discounts = new List<Discount>
            {
                new Discount
                {
                    Id = 1,
                    Percentage = 10m,
                    ProductId = 1,
                    Product = new Product
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
                    StartTime = DateTime.Now,
                    EndTime = DateTime.ParseExact("31/12/2090", "dd/MM/yyyy", null)
                }
            };
        }

        private ICollection<Discount> Discounts { get; }

        public void AddDiscount(Discount discount)
        {
            Discounts.Add(discount);
        }

        public void RemoveDiscount(Discount discount)
        {
            Discounts.Remove(discount);
        }

        public void UpdateDiscount(Discount discount)
        {
            Discounts.Remove(Discounts.First(d => d.Id == discount.Id));
            Discounts.Add(discount);
        }

        public Discount GetDiscount(long id)
        {
            return Discounts.First(d => d.Id == id);
        }

        public ICollection<Discount> GetAllDiscounts()
        {
            return Discounts;
        }

        public Product GetProductForDiscount(long id)
        {
            return GetDiscount(id).Product;
        }
    }
}