using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCar { get; set; }
        public int Sum => (int)ShopCar.ShopCarItems.Sum(c => c.Car.Price);
    }
}
