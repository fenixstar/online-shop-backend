using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class Product
{
    public long Id { get; set; }

    public int ProducerId { get; set; }

    public int CategoryId { get; set; }

    public int SubcategoryId { get; set; }

    [Required] [StringLength(200)] public string Name { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public int AvailableQuantity { get; set; }

    public Producer Producer { get; set; }
    public Category Category { get; set; }
    public Subcategory Subcategory { get; set; }
    public ICollection<Review> Reviews { get; set; }
    public ICollection<Discount> Discounts { get; set; }
    public ICollection<ProductPicture> ProductPictures { get; set; } = new List<ProductPicture>();
}