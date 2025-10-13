using CarMagazineISP_41.Data.Makets;
using CarMagazineISP_41.Data.Models;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Mvc;
using CarMagazineISP_41.Data.ViewModels;
using CarMagazineISP_41.Data.Infostructure;

namespace CarMagazineISP_41.Controllers
{
    public class HomeController : Controller
    {
        private CarDbContext db;
        public int pageSize = 5;
        int MaxPage 
        {
            get => (int)Math.Ceiling((decimal)db.Cars.Count() / pageSize);
        }
        public HomeController(CarDbContext context)
        {
            db = context;
        }
        
        public IActionResult Index(int category=1, int page=1)

        {
            ViewBag.Title = "main page";
            PageLinkTagHelper.categoryId=category;
            //ViewBag.maxPage = MaxPage;
            MockCars mockCars = new MockCars();
            return View(new IndexPagingModels
            {
                Cars = db.Cars
                   .OrderBy(c => c.CarId)
                   .Where(c=>c.CategoryId==category)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize)
                   .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = db.Cars
                    .Where(c=>c.CategoryId==category)
                    .Count()
                    
                },
                CurretCategory= category
            });
        }
        public IActionResult Error()
        {
            ViewBag.Title = "Error";
            return View();
        }
        public RedirectToActionResult AddAllCars()
        {
            var mockCars = new MockCars();
            foreach(var car in mockCars.Cars)
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
            return new RedirectToActionResult("Index", "Home", null);
        }

        public ActionResult CarInfo(int carId) 
        {
            ViewBag.Title = $"{db.Cars.Find(carId).CarName}";
            Car? car = db.Cars.Find(carId);
            return View(db.Cars.Find(carId));
        }
        public IActionResult CarList()
        {
            return View(db.Cars.ToList());
        }

    }
}
