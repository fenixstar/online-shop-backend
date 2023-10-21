using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities;

public class Review
{
    public long Id { get; set; }

    public long ApplicationUserId { get; set; }

    public long ProductId { get; set; }

    [Required] [Range(1, 6)] public int Rating { get; set; }

    [Required] [StringLength(1024)] public string Content { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Product Product { get; set; }
}