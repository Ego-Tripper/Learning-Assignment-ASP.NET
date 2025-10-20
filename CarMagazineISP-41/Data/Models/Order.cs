using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarMagazineISP_41.Data.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [Display(Name="Name")]
        [StringLength(50)]
        [Required (ErrorMessage ="Error")]
        public string Name { get; set; }
        [Display(Name = "SName")]
        [StringLength(50)]
        [Required(ErrorMessage = "Error")]
        public string SName { get; set; }
        [Display(Name = "Adress")]
        [StringLength(250)]
        [Required(ErrorMessage = "Error")]
        public string Adres { get; set; }
        [Display(Name = "Phone number")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Error")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Error")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail> OrderDetails { get; set; }= new List<OrderDetail>();
    }
}
