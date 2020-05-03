namespace Shop.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class Usuarios : IdentityUser
    {
        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        [Display(Name = "Nombre Completo")]
        public string FullName { get { return $"{this.Nombre} {this.PrimerApellido} {this.SegundoApellido}"; } }

    }
}
