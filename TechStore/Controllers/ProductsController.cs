using System.Linq;
using TechStore.Models;
using TechStore.RepoServices;

namespace TechStore.Controllers
{
    public class ProductsController : Controller
    {
		public IProductRepository ProductRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IBrandRepository BrandRepository { get; }

        public ProductsController(IProductRepository productRepository , ICategoryRepository categoryRepository , IBrandRepository brandRepository)
        {
			ProductRepository = productRepository;
            CategoryRepository = categoryRepository;
            BrandRepository = brandRepository;
        }


        public IActionResult Index()
        {
            return View(ProductRepository.GetProducts());
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateProductFormViewModel viewModel = new CreateProductFormViewModel();
            
            var Categories = CategoryRepository.GetCategories();
            viewModel.Categories = Categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
            
            var Brands = BrandRepository.GetBrands();
            viewModel.Brands = Brands.Select(b => new SelectListItem
            {
                Value = b.Id.ToString(),
                Text = b.Name
            });


            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductFormViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Description = viewModel.Description,
                    BrandId = viewModel.BrandId,
                    CategoryId = viewModel.CategoryId,
                    Cover = viewModel.Cover
                };
                ProductRepository.AddProduct(product);
                return RedirectToAction("Index");
            }
            return View(viewModel);   
        }

        public IActionResult Details(int id)
        {
            return View(ProductRepository.GetProduct(id));
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Product product = ProductRepository.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id , Product product)
        {
            product = ProductRepository.GetProduct(id);
            if(product == null)
            {
                return NotFound();
            }   
            ProductRepository.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Product product = ProductRepository.GetProduct(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(int id , Product product)
        {
            ProductRepository.UpdateProduct(id , product);
            return RedirectToAction("Index");
        }
    }
}
