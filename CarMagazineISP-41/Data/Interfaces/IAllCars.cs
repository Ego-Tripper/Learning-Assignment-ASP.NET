using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.Interfaces
{
    public interface IAllCars
    {
        /// <summary>
        /// Генерирует список всех автомобилей
        /// </summary>
        IEnumerable<Car> Cars { get;  }
        /// <summary>
        /// Генерирует список избранных авто
        /// </summary>
        IEnumerable<Car> GetFavCars { get;  }
        /// <summary>
        /// Выводит авто по его идентификатор
        /// </summary>
        /// <param name="carId"> Идентификатор</param>
        /// <returns></returns>
        Car GetOneCar(int carId);
    }
}
