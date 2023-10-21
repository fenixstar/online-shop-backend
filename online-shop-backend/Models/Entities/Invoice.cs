using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using online_shop_backend.Models.Identity;

namespace online_shop_backend.Models.Entities;

public class Invoice
{
    public long Id { get; set; }

    public string ApplicationUserId { get; set; }

    public long OrderId { get; set; }

    public decimal TotalValue { get; set; }

    [Required] public DateTime DateIssued { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
    public Order Order { get; set; }
    public ICollection<InvoiceDetail> Details { get; set; }
}