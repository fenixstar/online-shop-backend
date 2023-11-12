using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class Category
{
    public int Id { get; set; }
    
    public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();
    
    [Required] 
    [StringLength(200)] 
    public string Title { get; set; }

    public string Icon { get; set; }
    
    [Required]
    public bool IsActual { get; set; }
}