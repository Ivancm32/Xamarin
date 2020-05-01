namespace Shop.Web1.Data
{
    using Entities;
    using System.Linq;

    public interface IRepositorioProductos : IRepositorioGenerico<Productos>
    {
        IQueryable GetAllWithUsers();
    }
}
