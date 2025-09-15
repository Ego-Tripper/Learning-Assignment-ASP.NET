namespace CarMagazineISP_41.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public List <Car> Cars { get; set; }= new List<Car> ();
    }
}
