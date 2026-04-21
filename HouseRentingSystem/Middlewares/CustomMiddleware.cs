using HouseRentingSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HouseRentingSystem.Middlewares
{
    public class CustomMiddleware
    {
        private RequestDelegate next;
        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, HouseRentingDbContext context)
        {
            var housesCount = await context.Houses.CountAsync();
            Console.WriteLine(housesCount);
            await this.next(httpContext);
        }
    }
}
