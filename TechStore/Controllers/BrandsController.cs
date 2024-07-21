using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechStore.Models;
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
			return View(BrandRepository.GetBrand(id));
		}

		// GET: BrandsController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: BrandsController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Brand brand)
		{
			try
			{
				if(ModelState.IsValid)
				{
					BrandRepository.AddBrand(brand);
					return RedirectToAction(nameof(Index));
                }
            }
			catch
			{
					return View("Error");
			}
			return View(brand);
		}

		// GET: BrandsController/Edit/5
		public ActionResult Edit(int id)
		{
			Brand brand = BrandRepository.GetBrand(id);
			return View(brand);
		}

		// POST: BrandsController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Brand brand)
		{
			try
			{
				if (ModelState.IsValid)
				{
					Brand Editedbrand = BrandRepository.GetBrand(id);
					if (Editedbrand != null)
					{
                        Editedbrand.Description = brand.Description;
                        Editedbrand.Name = brand.Name;
                        Editedbrand.Icon = brand.Icon;
                        BrandRepository.UpdateBrand(id, Editedbrand);
						return RedirectToAction(nameof(Index));
					}
				}
				return View(brand);
            }
            catch
			{
				return View("Error");
			}
		}

		// GET: BrandsController/Delete/5
		public ActionResult Delete(int id)
		{ 
			Brand brand = BrandRepository.GetBrand(id);
			return View(brand);
		}

		// POST: BrandsController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, Brand brand)
		{
			try
			{
				BrandRepository.DeleteBrand(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View(brand);
			}
		}
	}
}
