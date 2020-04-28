namespace Shop.Web.Data
{
	using Shop.Web.Data.Entities;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;
	public class Repositorio : IRepositorio
	{
		private readonly DataContext context;

		public Repositorio(DataContext context)
		{
			this.context = context;
		}
		public IEnumerable<Productos> GetProducts() // IEnumerable es una lista
		{
			return this.context.productos.OrderBy(p => p.Nombre);
		}

		public Productos GetProduct(int id)
		{
			return this.context.productos.Find(id);
		}

		public void AddProduct(Productos productos)
		{
			this.context.productos.Add(productos);
		}

		public void UpdateProduct(Productos productos)
		{
			this.context.Update(productos);
		}

		public void RemoveProduct(Productos productos)
		{
			this.context.productos.Remove(productos);
		}

		public async Task<bool> SaveAllAsync()
		{
			return await this.context.SaveChangesAsync() > 0;
		}

		public bool ProductExists(int id)
		{
			return this.context.productos.Any(p => p.Id == id);
			//return this.context.productos.Any(p => p.Nombre.Contains('Z'));
		}
	}
}