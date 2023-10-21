using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using online_shop_backend.Controllers;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;
using online_shop_backend.tests.Mocks;
using Xunit;

namespace online_shop_backend.tests.Tests.Controllers
{
    public class OrderControllerTests
    {
        private readonly OrderController orderController;
        private readonly IOrderRepository orderRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IProductRepository productRepository;
        private readonly IShippingMethodRepository shippingMethodRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderControllerTests()
        {
            orderRepository = new SampleOrderRepository();
            productRepository = new SampleProductRepository();
            shippingMethodRepository = new SampleShippingMethodRepository();
            paymentTypeRepository = new SamplePaymentTypeRepository();
            userManager = TestUtils.CreateUserManager<ApplicationUser>();

            orderController = new OrderController(orderRepository, productRepository,
                shippingMethodRepository, paymentTypeRepository, userManager);
        }

        [Fact]
        public void AddsOrderCorrectly()
        {
            var cartObject = new CartDto
            {
                Note = "Note1",
                ShippingMethodId = 1,
                Username = "User1",
                CartItems = new List<CartItemDto>
                {
                    new CartItemDto
                    {
                        ProductId = 1,
                        Quantity = 10
                    }
                }
            };

            var result = orderController.Index(cartObject)?.Result;

            Assert.Equal(JsonConvert.SerializeObject(orderRepository.GetAllOrders().Last()),
                JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void DoesNotAddOrderIfProductIsNotAvailable()
        {
            var cartObject = new CartDto
            {
                Note = "Note1",
                ShippingMethodId = 1,
                Username = "User1",
                CartItems = new List<CartItemDto>
                {
                    new CartItemDto
                    {
                        ProductId = 1,
                        Quantity = 25
                    }
                }
            };

            var result = orderController.Index(cartObject)?.Result;

            Assert.Null(result);
        }
    }
}