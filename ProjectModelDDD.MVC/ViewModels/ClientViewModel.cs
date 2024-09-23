using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectModelDDD.MVC.ViewModels
{
    public class ClientViewModel
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(150, ErrorMessage = "Max {0} character")]
        [MinLength(2, ErrorMessage = "Min {0} character")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(150, ErrorMessage = "Max {0} character")]
        [MinLength(2, ErrorMessage = "Min {0} character")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Max {0} character")]
        [EmailAddress(ErrorMessage = "Invalid e-mail address")]
        [DisplayName("e-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public DateTime RegisterDate { get; set; }

        public bool IsActive { get; set; }

        public virtual IEnumerable<ProductViewModel> Products { get; set; }
    }
}