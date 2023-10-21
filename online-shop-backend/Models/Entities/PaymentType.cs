using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class PaymentType
{
    public int Id { get; set; }

    [Required] [StringLength(100)] public string Name { get; set; }

    public ICollection<PaymentMethod> PaymentMethods { get; set; }
}