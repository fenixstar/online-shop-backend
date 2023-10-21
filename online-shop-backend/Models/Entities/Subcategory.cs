using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class Subcategory
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    [Required] [StringLength(200)] public string Title { get; set; }

    public Category Category { get; set; }
}