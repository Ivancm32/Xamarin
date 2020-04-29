namespace Shop.Web.Data
{
    using Entities;
    public class RepositorioProductos : RepositorioGenerico<Productos>, IRepositorioProductos
    {
        public RepositorioProductos(DataContext context) : base(context)
        {

        }
    }
}
