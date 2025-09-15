using CarMagazineISP_41.Data.Interfaces;
using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.Makets
{
    public class MocCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories => new List<Category> 
        {
            new Category{CategoryId=1,
                CategoryName="Электромобили", 
                Description="Современный вид транспорта"},
            new Category{CategoryId=2,
                CategoryName="BurgenTruck",
                Description="Еду по шоссе"},

        };
    }
}
