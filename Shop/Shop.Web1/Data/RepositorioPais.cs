namespace Shop.Web1.Data
{
    using Entities;
    public class RepositorioPais : RepositorioGenerico<Pais>, IRepositorioPais
    {
        public RepositorioPais(DataContext context) : base(context)
        {

        }
    }
}