namespace Shop.Web1.Models
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [BindProperty]
        public LoginViewModel Input { get; set; }
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
        public string ReturnUrl { get; set; }

        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }



    }
}
