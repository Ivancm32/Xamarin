﻿namespace Shop.Web.Helper
{
	using Data.Entities;
	using Microsoft.AspNetCore.Identity;
    using Shop.Web.Models;
    using System.Threading.Tasks;
	public interface IUserHelper
	{
		Task<Usuarios> GetUserByEmailAsync(string email);

		Task<IdentityResult> AddUserAsync(Usuarios user, string password);

		Task<SignInResult> LoginAsync(LoginViewModel model);

		Task LogoutAsync();

	}
}