using CarMagazineISP_41.Data.Models;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarMagazineISP_41.Controllers
{
    public class OrderController : Controller
    {
        CarDbContext context;
        ShopCart cart;
        public OrderController(CarDbContext context, ShopCart cart)
        {
            this.context = context;
            this.cart = cart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            cart.ShopCarItems = cart.GetShopCarItems();
            if (cart.ShopCarItems.Count == 0)
            {
                ModelState.AddModelError("", "Error: plese add goods ");
            }
            if (ModelState.IsValid)
            {
                CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        private void CreateOrder(Order order)
        {
            order.OrderTime= DateTime.Now;
            context.Orders.Add(order);
            context.SaveChanges();
            var items = cart.GetShopCarItems();
            foreach (var item in items)
            {
                context.OrderDetails.Add(new OrderDetail { CarId = item.Car.CarId, OrderId = order.Id, Price = item.Car.Price, });
            }
            context.SaveChanges();
        }
        public IActionResult Complete()
        {
            ViewBag.Massage = "Order Create";
            return View();
        }
    }
}
