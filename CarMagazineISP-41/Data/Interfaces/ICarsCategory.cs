using CarMagazineISP_41.Data.Models;

namespace CarMagazineISP_41.Data.Interfaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
