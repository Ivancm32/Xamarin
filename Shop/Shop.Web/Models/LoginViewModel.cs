using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Models
{

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
