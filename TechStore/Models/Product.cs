using System.ComponentModel.DataAnnotations.Schema;

namespace TechStore.Models
{
    public class Product : BaseEntity
    {
        [Precision(10 , 2)]
        public decimal Price { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        [MaxLength(500)]
        public string Cover { get; set; } = string.Empty;

    }
}

