namespace Shop.Web1.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
    using Models;
    using System.Threading.Tasks;
	public interface IUserHelper
	{
		Task<Usuarios> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(Usuarios user, string password);

		Task<SignInResult> LoginAsync(LoginViewModel model);

		Task LogoutAsync();

	}
}