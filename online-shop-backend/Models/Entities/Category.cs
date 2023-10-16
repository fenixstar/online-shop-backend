using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace online_shop_backend.Models.Entities
{
    public class Category
    {
        public string Icon { get; set; }
        public ICollection<Subcategory> Subcategories { get; set; } = new List<Subcategory>();

        public int ID { get; set; }

        [Required] [StringLength(200)] public string Title { get; set; }
    }
}