﻿namespace Shop.Web.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
	using Shop.Web.Models;
	using System.Threading.Tasks;

	public class UserHelper : IUserHelper
	{
		private readonly UserManager<Usuarios> userManager;
		private readonly SignInManager<Usuarios> signInManager;
		private readonly RoleManager<IdentityRole> roleManager;

		public UserHelper(UserManager<Usuarios> UserManager,
			SignInManager<Usuarios> SignInManager,
	RoleManager<IdentityRole> roleManager)
		{
			userManager = UserManager;
			signInManager = SignInManager;
			this.roleManager = roleManager;
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

		public async Task<IdentityResult> UpdateUserAsync(Usuarios user)
		{
			return await this.userManager.UpdateAsync(user);
		}

		public async Task<IdentityResult> ChangePasswordAsync(Usuarios user, string oldPassword, string newPassword)
		{
			return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
		}

		public async Task<SignInResult> ValidatePasswordAsync(Usuarios user, string password)
		{
			return await this.signInManager.CheckPasswordSignInAsync(
				user,
				password,
				false);
		}

		public async Task CheckRoleAsync(string roleName)
		{
			var roleExists = await this.roleManager.RoleExistsAsync(roleName);
			if (!roleExists)
			{
				await this.roleManager.CreateAsync(new IdentityRole
				{
					Name = roleName
				});
			}
		}

		public async Task AddUserToRoleAsync(Usuarios user, string roleName)
		{
			await this.userManager.AddToRoleAsync(user, roleName);
		}

		public async Task<bool> IsUserInRoleAsync(Usuarios user, string roleName)
		{
			return await this.userManager.IsInRoleAsync(user, roleName);
		}

	}
}