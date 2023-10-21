using System;
using System.Collections.Generic;
using System.Linq;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.tests.Mocks
{
    public class SampleOrderRepository : IOrderRepository
    {
        public SampleOrderRepository()
        {
            Orders = new List<Order>
            {
                new Order
                {
                    Id = 1,
                    ApplicationUser = new ApplicationUser
                    {
                        Id = "1",
                        UserName = "User1",
                        Email = "User1@email.com"
                    },
                    ShippingMethod = new ShippingMethod
                    {
                        Id = 1,
                        Name = "Method1",
                        Price = 2.99m
                    },
                    Note = "Sample note",
                    ShippingMethodPrice = 2.99m,
                    Details = new List<OrderDetail>
                    {
                        new OrderDetail
                        {
                            Id = 1,
                            OrderId = 1,
                            Quantity = 5,
                            UnitPrice = 15.5m,
                            Product = new Product
                            {
                                Id = 1,
                                Name = "Product1",
                                AvailableQuantity = 10,
                                Price = 15.5m,
                                CategoryId = 1,
                                SubcategoryId = 1
                            }
                        }
                    }
                }
            };
        }

        private ICollection<Order> Orders { get; }

        public void AddOrder(Order order)
        {
            Orders.Add(order);
        }

        public void RemoveOrder(Order order)
        {
            Orders.Remove(order);
        }

        public void UpdateOrder(Order order)
        {
            Orders.Remove(Orders.First(o => o.Id == order.Id));
            Orders.Add(order);
        }

        public Order GetOrder(long id)
        {
            return Orders.First(o => o.Id == id);
        }

        public ICollection<Order> GetAllOrders()
        {
            return Orders;
        }

        public ICollection<Order> GetOrdersForUser(string userId)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser GetUserForOrder(long id)
        {
            return GetOrder(id).ApplicationUser;
        }

        public ShippingMethod GetShippingMethodForOrder(long id)
        {
            return GetOrder(id).ShippingMethod;
        }

        public ICollection<OrderDetail> GetDetailsForOrder(long id)
        {
            return GetOrder(id).Details;
        }
    }
}