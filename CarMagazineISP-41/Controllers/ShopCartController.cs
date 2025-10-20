using CarMagazineISP_41.Data.Models;
using CarMagazineISP_41.Data.ViewModels;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace CarMagazineISP_41.Controllers
{
    public class ShopCartController : Controller
    {
        ShopCart shopCart;
        private readonly CarDbContext db;

        public ShopCartController(ShopCart shopCart ,CarDbContext context)
        {
            db = context;
            this.shopCart = shopCart;
        }

       public ViewResult Index()
        {
            shopCart.ShopCarItems = shopCart.GetShopCarItems();
            return View(new ShopCartViewModel { ShopCar = shopCart});
        }
        public IActionResult AddToCart(int carId)
        {
            var car = db.Cars.Find(carId);
            if (car == null)
            {
                return NotFound(); // Если автомобиль не найден, возвращаем ошибку
            }

            var shopCar = ShopCart.GetCar(HttpContext.RequestServices); // Получаем текущую корзину
            shopCar.AddToCart(car); // Добавляем автомобиль в корзину

            return RedirectToAction("Index", "ShopCart"); // Перенаправление на страницу корзины
        }

    }
}
