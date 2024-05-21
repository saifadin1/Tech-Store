

namespace TechStore.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDBcontext _DbContext; 

        public ProductsController(AppDBcontext DbContext) 
        {
			_DbContext = DbContext; 
		}

       

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateProductFormViewModel ViewModel = new()
            {
                Brands = _DbContext.Brands.Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Name
                })
                .OrderBy(b => b.Text)
                .ToList(),

                Categories = _DbContext.Categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .OrderBy(c => c.Text)
                .ToList()
			};
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        
    }
}
