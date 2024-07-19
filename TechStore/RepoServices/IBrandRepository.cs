using TechStore.Models;

namespace TechStore.RepoServices
{
	public interface IBrandRepository
	{
		IEnumerable<Brand> GetBrands();
		Brand GetBrand(int id);
		void AddBrand(Brand brand);
		void UpdateBrand(int id, Brand brand);
		void DeleteBrand(int id);
	}
}
