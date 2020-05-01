namespace Shop.Web.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using Shop.Web.Models;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{
		private readonly SignInManager<Usuarios> signInManager;
		private readonly UserManager<Usuarios> userManager;

		public UserHelper(SignInManager<Usuarios> signInManager,
			UserManager<Usuarios> userManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
		}

		public async Task<IdentityResult> AddUserAsync(Usuarios user, string password)
		{
			return await this.userManager.CreateAsync(user, password);
		}

		public async Task<Usuarios> GetUserByEmailAsync(string email)
		{
			var user = await this.userManager.FindByEmailAsync(email);
			return user;
		}

		public async Task<SignInResult> LoginAsync(LoginViewModel model)
		{
			return await this.signInManager.PasswordSignInAsync(
		model.Username,
		model.Password,
		model.RememberMe,
		false);

		}

		public async Task LogoutAsync()
		{
			await this.signInManager.SignOutAsync();
		}
	}
}