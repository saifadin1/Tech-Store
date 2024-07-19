using TechStore.Models;

namespace TechStore.RepoServices
{
	public class CategoryRepoService : ICategoryRepository
	{
		public AppDBcontext Context { get; }

		public CategoryRepoService(AppDBcontext Context)
        {
			this.Context = Context;
		}

		public void AddCategory(Category category)
		{
			if(category != null)
			{
				Context.Categories.Add(category);
			}
		}

		public void DeleteCategory(int id)
		{
			Category category = Context.Categories.Find(id);
			if(category != null)
			{
				Context.Categories.Remove(category);
			}
		}

		public IEnumerable<Category> GetCategories()
		{
			return Context.Categories.ToList();
		}

		public Category GetCategory(int id)
		{
			return Context.Categories.Find(id);
		}

		public void UpdateCategory(int id, Category category)
		{
			Category EditedCategory = Context.Categories.Find(id);
			if(EditedCategory != null)
			{
				EditedCategory.Name = category.Name;
				EditedCategory.Icon = category.Icon;
			}

		}
	}
}
