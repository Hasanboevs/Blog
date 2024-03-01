using Infinite_Skunome.Data;
using Infinite_Skunome.Models;
using Infinite_Skunome.Utilites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infinite_Skunome
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddControllersWithViews();

			var connection = builder.Configuration.GetConnectionString("MyConnection");

			builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseNpgsql(connection) );

			builder.Services.AddIdentity<ApplicationUser, WebsiteRoles>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}