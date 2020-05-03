namespace Shop.Web.Data
{
	using System.Linq;
	using System.Threading.Tasks;
	public interface IRepositorioGenerico<T> where T : class // <T> notacion diamante podemos cambiar T x cualquier cosa
	{


		IQueryable<T> GetAll(); // Nos devuelve una lista de T

		Task<T> GetByIdAsync(int id);

		Task CreateAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task<bool> ExistAsync(int id);
	}
}

