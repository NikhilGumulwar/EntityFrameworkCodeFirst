using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsApi.Models
{
    public class Product
    {
            [Key]
            public int ProductId { get; set; }

            [Required]
            public string Name { get; set; }

            public string Category { get; set; }

            public int Price { get; set; }

        public  ICollection<Review> Reviews { get; set; }
    }
}