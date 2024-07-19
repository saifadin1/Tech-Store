using TechStore.Models;

namespace TechStore.RepoServices
{
	public class BrandRepoService : IBrandRepository
	{
		public AppDBcontext Context { get; }

		public BrandRepoService(AppDBcontext Context)
        {
			this.Context = Context;
		}

		public void AddBrand(Brand brand)
		{
			if(brand != null)
			{
				Context.Brands.Add(brand);
			}
		}

		public void DeleteBrand(int id)
		{
			Brand brand = Context.Brands.Find(id);
			if(brand != null)
			{
				Context.Brands.Remove(brand);
			}
		}

		public Brand GetBrand(int id)
		{
			return  Context.Brands.Find(id);
		}

		public IEnumerable<Brand> GetBrands()
		{
			return Context.Brands.ToList();
		}

		public void UpdateBrand(int id, Brand brand)
		{
			Brand EditedBrand = Context.Brands.Find(id);
			if(EditedBrand != null)
			{
				EditedBrand.Description = brand.Description;
				EditedBrand.Name = brand.Name;
				EditedBrand.Icon = brand.Icon;
			}
		}
	}
}
