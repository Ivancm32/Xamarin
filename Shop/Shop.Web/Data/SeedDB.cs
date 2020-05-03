namespace Shop.Web.Data
{
    using Entities;
    using Helper;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDB
    {
        //INYECCION DE LA  BASE DE DATOS
        private readonly DataContext _context;
        private readonly IUserHelper userHelper;

        // private readonly UserManager<Usuarios> userManager;
        private readonly Random _random;

        // public SeedDB(DataContext context, UserManager<Usuarios> userManager)
        public SeedDB(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            this.userHelper = userHelper;
            // this.userManager = userManager;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            await _context.Database.EnsureCreatedAsync();

            // var usuarios = await this.userManager.FindByEmailAsync("Icastro@tas-seguridad.com");
            var usuarios = await this.userHelper.GetUserByEmailAsync("Icastro@tas-seguridad.com");
            if (usuarios == null)
            {
                usuarios = new Usuarios
                {
                    Nombre = "Iván",
                    PrimerApellido = "Castro",
                    SegundoApellido = "Muñoz",
                    Email = "Icastro@tas-seguridad.com",
                    UserName = "Icastro@tas-seguridad.com",
                    PhoneNumber = "61824529"
                };

                //   var result = await this.userManager.CreateAsync(usuarios, "Ivancm32");
                var result = await this.userHelper.AddUserAsync(usuarios, "Ivancm32");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("No se puede crear el usuario en el SeedDB");
                }

                await this.userHelper.AddUserToRoleAsync(usuarios, "Admin");
            }

            var isInRole = await this.userHelper.IsUserInRoleAsync(usuarios, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(usuarios, "Admin");
            }



            if (!_context.productos.Any())//Si no hay algun producto ingresa estos
            {
                this.AddProduct("Dell", usuarios);
                this.AddProduct("Mac", usuarios);
                this.AddProduct("Compaq", usuarios);
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, Usuarios usuario)
        {
            _context.productos.Add(new Productos
            {
                Nombre = name,
                Precio = this._random.Next(200000, 600000),
                Disponi = true,
                Stock = this._random.Next(100),
                Usuarios = usuario
            });

        }
    }
}
