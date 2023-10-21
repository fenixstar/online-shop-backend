namespace online_shop_backend.Models.Entities;

public class ProductPicture
{
    public long Id { get; set; }
    public long ProductId { get; set; }

    public string PictureUrl { get; set; }
    public Product Product { get; set; }
}