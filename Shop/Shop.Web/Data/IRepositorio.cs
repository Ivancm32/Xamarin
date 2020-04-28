using Shop.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shop.Web.Data
{
    public interface IRepositorio
    {
        void AddProduct(Productos productos);
        Productos GetProduct(int id);
        IEnumerable<Productos> GetProducts();
        bool ProductExists(int id);
        void RemoveProduct(Productos productos);
        Task<bool> SaveAllAsync();
        void UpdateProduct(Productos productos);
    }
}