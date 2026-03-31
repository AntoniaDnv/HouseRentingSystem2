using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");
			
			builder.Services.AddDbContext<HouseRentingDbContext>(opt => opt.UseSqlServer(connectionString));
			
			builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequiredLength = 6;
				opt.Password.RequireLowercase = false;
				opt.Password.RequireUppercase = false;
				opt.SignIn.RequireConfirmedEmail = false;
			})
				.AddEntityFrameworkStores<HouseRentingDbContext>()
				.AddDefaultTokenProviders();
			builder.Services.ConfigureApplicationCookie(opt =>
			{
				opt.LoginPath = "/User/Login";
				opt.AccessDeniedPath = "/User/AccessDenied";
			});
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
