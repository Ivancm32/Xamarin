namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class ChangeUserViewModel
    {

        [Required]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public string PApellido { get; set; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public string SApellido { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; }
    }

}
