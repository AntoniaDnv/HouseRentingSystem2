using System.Diagnostics;

namespace HouseRentingSystem.Middlewares
{
    public class TimeCountingMiddleware
    {
        private RequestDelegate next;
        public TimeCountingMiddleware(RequestDelegate next) 
        {
         this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await this.next(httpContext);
            stopwatch.Stop();
            Console.WriteLine("Time to execute the http request:" + stopwatch.ElapsedMilliseconds);
        }
    }
}
