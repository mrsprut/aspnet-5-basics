using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace aspnet5basics.Middleware
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public RoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string path = context.Request.Path.Value?.ToLower();
            if (path == "/account")
            {
                await context.Response.WriteAsync("Account Page");
            }
            else if (path == "/sign-in")
            {
                await context.Response.WriteAsync("Sign In Page");
            }
            else
            {
                context.Response.StatusCode = 404;
            }
            //await _next.Invoke(context);
        }
    }
}