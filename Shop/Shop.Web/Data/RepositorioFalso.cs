using Shop.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public class RepositorioFalso : IRepositorio
    {
        public void AddProduct(Productos productos)
        {
            throw new NotImplementedException();
        }

        public Productos GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Productos> GetProducts()
        {
            var productos = new List<Productos>();
            productos.Add(new Productos { Id = 1, Nombre = "Uno", Precio = 10 });
            productos.Add(new Productos { Id = 2, Nombre = "Dos", Precio = 20 });
            productos.Add(new Productos { Id = 3, Nombre = "Tres", Precio = 30 });
            productos.Add(new Productos { Id = 4, Nombre = "Cuatro", Precio = 40 });
            productos.Add(new Productos { Id = 5, Nombre = "Cinco", Precio = 50 });
            return productos;
        }

        public bool ProductExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Productos productos)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAllAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Productos productos)
        {
            throw new NotImplementedException();
        }
    }
}
