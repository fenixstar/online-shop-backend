using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities;

public class Producer
{
    public ICollection<ProducerDetail> Details;
    public int Id { get; set; }

    [Required] [StringLength(200)] public string Name { get; set; }
}