namespace Shop.Web1.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public class RepositorioProductos : RepositorioGenerico<Productos>, IRepositorioProductos
    {
        private readonly DataContext context;

        public RepositorioProductos(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.productos.Include(p => p.Usuarios);
        }
    }
}
