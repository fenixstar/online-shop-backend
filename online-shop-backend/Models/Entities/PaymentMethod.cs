using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities;

public class PaymentMethod
{
    public long Id { get; set; }

    public int PaymentTypeId { get; set; }

    public long ApplicationUserId { get; set; }

    [Required] [StringLength(512)] public string Value { get; set; }

    public PaymentType PaymentType { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}