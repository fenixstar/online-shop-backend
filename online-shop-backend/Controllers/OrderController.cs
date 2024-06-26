using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using online_shop_backend.Models.DTO;
using online_shop_backend.Models.Entities;
using online_shop_backend.Models.Identity;
using online_shop_backend.Repositories.Interfaces;

namespace online_shop_backend.Controllers;

[Route("/api/order")]
[AllowAnonymous]
public class OrderController(IOrderRepository orderRepository,
        IProductRepository productRepository,
        IShippingMethodRepository shippingMethodRepository,
        IPaymentTypeRepository paymentTypeRepository,
        UserManager<ApplicationUser> userManager)
    : Controller
{
    [HttpGet("{id:required}")]
    [Authorize]
    public Order GetOrderForId(long id)
    {
        var order = orderRepository.GetOrder(id);

        if (order == null) return null;

        order.Details = orderRepository.GetDetailsForOrder(id);
        order.ShippingMethod = shippingMethodRepository.GetShippingMethod(order.ShippingMethodId);

        foreach (var detail in order.Details) detail.Product = productRepository.GetProduct(detail.ProductId);

        return order;
    }

    [HttpPost]
    [Authorize]
    public async Task<Order> Index([FromBody] CartDto cart)
    {
        var orderToAdd = new Order
        {
            ApplicationUserId = (await userManager.FindByNameAsync(cart.Username)).Id,
            ShippingMethodId = cart.ShippingMethodId,
            Note = cart.Note,
            DateAndTime = DateTime.Now,
            Details = new List<OrderDetail>(),
            ShippingMethodPrice = shippingMethodRepository.GetShippingMethod(cart.ShippingMethodId).Price
        };


        foreach (var item in cart.CartItems)
        {
            if (!productRepository.CheckIfProductIsAvailable(item.ProductId, item.Quantity)) return null;

            orderToAdd.Details.Add(new OrderDetail
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                UnitPrice = productRepository.GetProduct(item.ProductId).Price,
                Product = productRepository.GetProduct(item.ProductId)
            });
        }

        orderRepository.AddOrder(orderToAdd);

        foreach (var detail in orderToAdd.Details)
        {
            var product = detail.Product;
            product.AvailableQuantity -= detail.Quantity;

            productRepository.UpdateProduct(product);
        }

        return orderToAdd;
    }

    [HttpGet("last")]
    public List<Product> GetLastOrderedProducts()
    {
        var lastOrders = orderRepository.GetAllOrders().Take(3);

        var productsToReturn = new List<Product>();

        var orders = lastOrders.ToList();
        if (orders.Any())
            foreach (var order in orders)
            foreach (var detail in orderRepository.GetDetailsForOrder(order.Id))
                productsToReturn.Add(
                    productRepository.GetProduct(detail.ProductId));

        return productsToReturn.Take(4).ToList();
    }

    [HttpGet("shipping-methods")]
    public List<ShippingMethod> GetShippingMethods()
    {
        return shippingMethodRepository.GetAllShippingMethods().ToList();
    }

    [HttpGet("payment-types")]
    public List<PaymentType> GetPaymentTypes()
    {
        return paymentTypeRepository.GetAllPaymentTypes().ToList();
    }

    [HttpPost("history")]
    [Authorize]
    public async Task<List<Order>> OrderHistory([FromBody] UserDto user)
    {
        var retrievedUser = await userManager.FindByNameAsync(user.Username);

        return orderRepository.GetOrdersForUser(retrievedUser.Id).ToList();
    }
}