using TechStore.Models;

namespace TechStore.RepoServices
{
	public interface ICategoryRepository
	{
		IEnumerable<Category> GetCategories();
		Category GetCategory(int id);
		void AddCategory(Category category);
		void UpdateCategory(int id , Category category);
		void DeleteCategory(int id);
	}
}
