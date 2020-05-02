using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Password Actual")]
        public string OldPassword { get; set; }

        [Required]
        [Display(Name = "Nueva Contraseña")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        [Display(Name = "Nueva Contraseña")]
        public string Confirm { get; set; }

    }
}
