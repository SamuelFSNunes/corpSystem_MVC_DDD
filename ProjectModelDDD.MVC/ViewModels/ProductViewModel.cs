
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProjectModelDDD.MVC.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(250, ErrorMessage = "Max {0} character")]
        [MinLength(2, ErrorMessage = "Min {0} character")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Range(typeof(decimal), "0", "999999999999")]
        [Required(ErrorMessage = "Value is required")]
        public decimal Value { get; set; }

        [DisplayName("Available?")]
        public bool Available { get; set; }

        public int ClientId { get; set; }

        public virtual ClientViewModel Client { get; set; }
    }
}