using CarMagazineISP_41.Data.Infostructure;
using CarMagazineISP_411.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CarMagazineISP_41.Views.Shared.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        CarDbContext db;
        public NavigationMenuViewComponent(CarDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = PageLinkTagHelper.categoryId;
            return View(db.Categories.OrderBy(cat => cat.CategoryName.ToString()));
        }
    }
}
