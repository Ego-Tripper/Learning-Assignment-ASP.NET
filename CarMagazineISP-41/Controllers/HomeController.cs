using CarMagazineISP_41.Data.Makets;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMagazineISP_41.Controllers
{
    public class HomeController : Controller
    {
        private CarDbContext db;
        public HomeController(CarDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
           
        {
            ViewBag.Title = "main page";
            MockCars mockCars = new MockCars();
            return View(db.Cars.ToList());
        }
        public IActionResult Error()
        {
            ViewBag.Title = "Error";
            return View();
        }
        public EmptyResult AddAllCars()
        {
            var mockCars = new MockCars();
            foreach(var car in mockCars.Cars)
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
            return new EmptyResult();
        }
    
    }
}
