using System.Collections.Generic;

namespace online_shop_backend.Models.DTO;

public class CartDto
{
    public ICollection<CartItemDto> CartItems { get; set; }
    public string Username { get; set; }
    public int ShippingMethodId { get; set; }
    public int PaymentTypeId { get; set; }
    public string Note { get; set; }
}