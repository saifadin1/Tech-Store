
namespace TechStore.ViewModels
{
    public class CreateProductFormViewModel
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [Precision(10, 2)]
        public decimal Price { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public IEnumerable<SelectListItem> Brands { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name="Category")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [MaxLength(500)]
        public IFormFile Cover { get; set; } = default!; 
    }
}
