namespace TechStore.Models
{
    public class Category
    {
        [MaxLength(500)]
        public string Icon { get; set; } = string.Empty;
    }
}
