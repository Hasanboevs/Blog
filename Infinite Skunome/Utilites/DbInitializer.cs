using Infinite_Skunome.Data;
using Infinite_Skunome.Models;
using Microsoft.AspNetCore.Identity;

namespace Infinite_Skunome.Utilites
{
	public class DbInitializer : IDbInitializer
	{
		private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public DbInitializer(AppDbContext db, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_db = db;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public void Initialize()
		{
			if (!_roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAdmin).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAdmin)).GetAwaiter();
				_roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAuthor)).GetAwaiter();
				_roleManager.CreateAsync(new IdentityRole()
				{
					UserName = "user",
					Email = "user@gmail.com",
					Name = "Yusuf"
				});
			}
		}
	}
}
