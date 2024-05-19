namespace TechStore.Models
{
    public class Category : BaseEntity
    {
        [MaxLength(500)]
        public string Icon { get; set; } = string.Empty;
    }
}
