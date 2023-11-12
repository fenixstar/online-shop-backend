using System.Collections.Generic;

namespace online_shop_backend.Models.DTO;

public class CategoryDto
{
    public string Title { get; set; }
    
    public ICollection<SubcategoryPageDto> Subcategories { get; set; }
}