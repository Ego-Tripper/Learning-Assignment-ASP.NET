using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarMagazineISP_41.Data.Models
{
    public class ShopCart
    {

        private CarDbContext db;
        public ShopCart(CarDbContext db)
        {
            this.db = db;
        }
        public string ShopCarId { get; set; }
        public List<ShopCartItem> ShopCarItems { get; set; }
        /// <summary>
        /// Определяет есть ли в корзине товары и если нет, то создаёт новую корзину.
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static ShopCart GetCar(IServiceProvider service)
        {
            //экземпляр  для работы с сессиями
            ISession? session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var  context = service.GetService<CarDbContext>();
            //сгенерируем id корзины
            string ShopCarId=session.GetString("CarId")??Guid.NewGuid().ToString();
            //применяем к каждому товару сгенерированный id
            session.SetString("CarId",ShopCarId);
            //вернём корзину с товарами
            return new ShopCart(context) {ShopCarId=ShopCarId};
        }
        //[HttpGet]
        public void AddToCart(Car car)
        {
            int price = (int)car.Price;
            db.ShopCarItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCarId, // ID корзины
                Car = car,
                Price = price,
            });
            db.SaveChanges(); // Сохранение изменений в базе
        }

        public List<ShopCartItem> GetShopCarItems()
        { 
        return db.ShopCarItem
                .Where(c=>c.ShopCartId==ShopCarId)
                .Include(s=>s.Car)
                .ToList();
        
        }

    }
}
