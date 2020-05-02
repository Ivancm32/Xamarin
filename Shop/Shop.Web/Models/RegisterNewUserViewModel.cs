namespace Shop.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterNewUserViewModel
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

        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string PhoneNumber { get; set; }
       

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Confirm { get; set; }
    }

}
