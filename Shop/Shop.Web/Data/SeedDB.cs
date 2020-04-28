namespace Shop.Web.Data
{
    using Shop.Web.Data.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDB
    {
        //INYECCION DE LA  BASE DE DATOS
        private readonly DataContext _context;
        private readonly Random _random;

        public SeedDB(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.productos.Any())//Si no hay algun producto ingresa estos
            {
                this.AddProduct("Dell");
                this.AddProduct("Mac");
                this.AddProduct("Compaq");
                await _context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name)
        {
            _context.productos.Add(new Productos
            {
                Nombre = name,
                Precio = this._random.Next(200000, 600000),
                Disponi = true,
                Stock = this._random.Next(100)
            });
        }
    }
}
