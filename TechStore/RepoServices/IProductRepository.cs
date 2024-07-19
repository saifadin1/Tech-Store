using TechStore.Models;

namespace TechStore.RepoServices
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		Product GetProduct(int id);
		void AddProduct(Product product);
		void UpdateProduct(int id , Product product);
		void DeleteProduct(int id);
	}
}
