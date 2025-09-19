using CarMagazineISP_41.Data.Interfaces;
using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.Makets
{
    public class MockCars : IAllCars
    {
        public IEnumerable<Car> Cars => new List<Car> { 
            new Car
            {
                CarId = 1,
                CarName = "Toyota Prius",
                ShortDescription = "Машина Брайана Гриффина",
                LongDescription = "Pivum Ipsum",
                Price = 1337000,
                IsFavourite = true,
                Available = true,
                CategoryId = 1
            },
            new Car
            {
                CarId = 2,
                CarName = "Tesla model X",
                ShortDescription = "Микроволовка",
                LongDescription = "Pivum Ipsum",
                Price = 4337000,
                IsFavourite = false,
                Available = true,
                CategoryId = 1
            },
            new Car
            {
                CarId = 3,
                CarName = "Xiaomi SU-7",
                ShortDescription = "Китайская Микроволовка",
                LongDescription = "Pivum Ipsum",
                Price = 2000000,
                IsFavourite = true,
                Available = false,
                CategoryId = 1
            },
            new Car
            {
                CarId = 4,
                CarName = "Ford F650",
                ShortDescription = "Еду по шоссе",
                LongDescription = "прям после пивка",
                Price = 1337000,
                IsFavourite = true,
                Available = true,
                CategoryId = 2
            },
            new Car
            {
                CarId = 5,
                CarName = "RAM TRX",
                ShortDescription = "Кажеться оленем",
                LongDescription = "Кочка из далека",
                Price = 4337000,
                IsFavourite = false,
                Available = true,
                CategoryId = 2
            },
            new Car
            {
                CarId = 6,
                CarName = "Toyota Hilux",
                ShortDescription = "Скажешь пьян С**бался **лан",
                LongDescription = "Я выжму сотню миль в час",
                Price = 2000000,
                IsFavourite = true,
                Available = false,
                CategoryId = 2
            },

        };
        public IEnumerable<Car> GetFavCars => Cars.Where(c=>c.IsFavourite==true);

        public Car GetOneCar(int carId) => Cars.FirstOrDefault(c => c.CarId == carId);
       
    }
}
