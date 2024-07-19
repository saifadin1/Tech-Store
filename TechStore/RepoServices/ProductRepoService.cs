using TechStore.Models;

namespace TechStore.RepoServices
{
	public class ProductRepoService : IProductRepository
	{
        // inject the db context
		public AppDBcontext Context { get; }

		public ProductRepoService(AppDBcontext context)
        {
			Context = context;
		}


		public void AddProduct(Product product)
		{
			if (product is Product) {
				Context.Products.Add(product);
				Context.SaveChanges();
			}
		}

		public void DeleteProduct(int id)
		{
			Product product = Context.Products.Find(id);
			if (product != null)
			{
				Context.Products.Remove(product);
				Context.SaveChanges();
			}
		}
		public Product GetProduct(int id)
		{
			return Context.Products.Find(id);
		}

		public IEnumerable<Product> GetProducts()
		{
			return Context.Products.Include(p=>p.BrandId)
									.Include(p=>p.CategoryId)
									.ToList();
		}

		public void UpdateProduct(int id, Product product)
		{
			Product product1 = Context.Products.Find(id);
			if(product1 is Product) 
			{
				product1.Price = product.Price;
				product1.Description = product.Description;
				product1.CategoryId = product.CategoryId;
				product1.BrandId = product.BrandId;
				product1.Name = product.Name;
				product1.Cover = product.Cover;
			}
		}
	}
}
