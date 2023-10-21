namespace online_shop_backend.Controllers;

public class ProductDto
{
    public long Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int AvailableQuantity { get; set; }
    
    public string[] PictureUrl { get; set; }
}