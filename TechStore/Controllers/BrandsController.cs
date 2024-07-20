using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.RepoServices;

namespace TechStore.Controllers
{
	public class BrandsController : Controller
	{

		public IBrandRepository BrandRepository { get; }

		public BrandsController(IBrandRepository brandRepository)
		{
			BrandRepository = brandRepository;
		}
		// GET: BrandsController
		public ActionResult Index()
		{
			return View(BrandRepository.GetBrands());
		}

		// GET: BrandsController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: BrandsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BrandsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BrandsController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: BrandsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: BrandsController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: BrandsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}
