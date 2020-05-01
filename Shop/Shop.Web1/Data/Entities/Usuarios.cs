namespace Shop.Web1.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class Usuarios : IdentityUser
    {
        public string Nombre { get; set; }

        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

    }
}
