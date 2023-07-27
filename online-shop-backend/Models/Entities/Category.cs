using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class Category
    {
        public ICollection<Subcategory> Subcategories;
        public int ID { get; set; }

        [Required] [StringLength(200)] public string Name { get; set; }
    }
}