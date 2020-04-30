namespace Shop.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IRepositorioProductos : IRepositorioGenerico<Productos>
    {
        IQueryable GetAllWithUsers();
    }
}
