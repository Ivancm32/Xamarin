namespace Shop.Web.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using System.Threading.Tasks;
	public interface IUserHelper
	{
		Task<Usuarios> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(Usuarios user, string password);

	}
}