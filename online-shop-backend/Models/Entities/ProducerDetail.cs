using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class ProducerDetail
{
    public long Id { get; set; }

    public int ProducerId { get; set; }

    [StringLength(30)] public string PhoneNumber { get; set; }

    [StringLength(200)] public string Email { get; set; }

    [StringLength(200)] public string Address1 { get; set; }

    [StringLength(200)] public string Address2 { get; set; }

    [StringLength(200)] public string City { get; set; }

    [StringLength(200)] public string Country { get; set; }

    public Producer Producer { get; set; }
}