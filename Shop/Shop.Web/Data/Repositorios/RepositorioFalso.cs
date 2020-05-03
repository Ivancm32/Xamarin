namespace Shop.Web.Data
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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
            var productos = new List<Productos>
            {
                new Productos { Id = 1, Nombre = "Uno", Precio = 10 },
                new Productos { Id = 2, Nombre = "Dos", Precio = 20 },
                new Productos { Id = 3, Nombre = "Tres", Precio = 30 },
                new Productos { Id = 4, Nombre = "Cuatro", Precio = 40 },
                new Productos { Id = 5, Nombre = "Cinco", Precio = 50 }
            };
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
