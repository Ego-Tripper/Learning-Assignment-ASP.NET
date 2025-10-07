using CarMagazineISP_41.Data.Interfaces;
using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.Makets
{
    public class MockCars : IAllCars
    {
        public IEnumerable<Car> Cars => new List<Car> { 
            

        };
        public IEnumerable<Car> GetFavCars => Cars.Where(c=>c.IsFavourite==true);

        public Car GetOneCar(int carId) => Cars.FirstOrDefault(c => c.CarId == carId);
       
    }
}
