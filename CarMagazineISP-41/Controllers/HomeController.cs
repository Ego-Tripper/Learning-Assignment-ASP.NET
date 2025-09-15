using CarMagazineISP_41.Data.Makets;
using Microsoft.AspNetCore.Mvc;

namespace CarMagazineISP_41.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
           
        {
            ViewBag.Title = "main page";
            MockCars mockCars = new MockCars();
            return View(mockCars.Cars);
        }
        public IActionResult Error()
        {
            ViewBag.Title = "Error";
            return View();
        }
    }
}
