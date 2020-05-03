namespace Shop.Web.Data
{
    using Entities;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
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

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = this.context.productos.Select(p => new SelectListItem
            {
                Text = p.Nombre,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccione un producto...)",
                Value = "0"
            });

            return list;
        }

    }
}
