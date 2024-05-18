namespace TechStore.Models
{
    public class Brand : BaseEntity
    {
        [MaxLength(2000)]
        public string Description { get; set; } = string.Empty;
        [MaxLength(500)]
        public string Icon { get; set; } = string.Empty;
    }
}
