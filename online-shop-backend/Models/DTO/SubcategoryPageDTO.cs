using System.Collections.Generic;
using online_shop_backend.Models.Entities;

namespace online_shop_backend.Models.DTO;

public class SubcategoryPageDto
{
    public Subcategory Subcategory { get; set; }
    public ICollection<Product> Products { get; set; }
}