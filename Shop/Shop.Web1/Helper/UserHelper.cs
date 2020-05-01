namespace Shop.Web1.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using Models;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<Usuarios> userManager;
		private readonly SignInManager<Usuarios> signInManager;

		public UserHelper(UserManager<Usuarios> UserManager,
			SignInManager<Usuarios> SignInManager)
		{
			userManager = UserManager;
			signInManager = SignInManager;
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