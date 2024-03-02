using Infinite_Skunome.Data;
using Infinite_Skunome.Models;
using Infinite_Skunome.Utilites;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Infinite_Skunome.Utilities
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

		public async Task Initialize()
		{
			await EnsureRolesAsync();

			List<Page> ListOfPages = new List<Page>()
			{
			new Page {Title = "About Us", Slug = "about"},
			new Page {Title = "Contact Us", Slug = "contact"},
			new Page {Title = "Privacy Plociy", Slug = "privacy-policy" }
			};

			_db.Pages.AddRange(ListOfPages);

		}

		private async Task EnsureRolesAsync()
		{
			if (!await _roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAdmin))
			{
				await _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAdmin));
			}

			if (!await _roleManager.RoleExistsAsync(WebsiteRoles.WebsiteAuthor))
			{
				await _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebsiteAuthor));
			}
		}

	}
}
