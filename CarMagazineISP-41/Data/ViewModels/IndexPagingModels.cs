using CarMagazineISP_41.Data.Models;



namespace CarMagazineISP_41.Data.ViewModels



{
    public class IndexPagingModels
    {
        public IEnumerable<Car>?Cars { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
