using HouseRentingSystem.Data;
using HouseRentingSystem.Data.Data.Entities;
using HouseRentingSystem.Middlewares;
using HouseRentingSystem.Services.Implementations;
using HouseRentingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
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
			builder.Services.AddScoped<IHouseService, HouseService>();
			var app = builder.Build();
			app.UseMiddleware<TimeCountingMiddleware>();
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseStatusCodePagesWithReExecute("Home/Error","?statusCode={0}");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			else
			{
				
                app.UseDeveloperExceptionPage();
					
            }

            app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.Use(async (context, next) =>
			{
				//incomming request
				var path = context.Request.Path;
				Console.WriteLine(path);
				await next();
				var statusCode = context.Response.StatusCode;
				Console.WriteLine(statusCode);
				//Outgoing response
			});
			
			app.UseMiddleware<CustomMiddleware>();
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
