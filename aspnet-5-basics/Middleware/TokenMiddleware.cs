using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace aspnet5basics.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate mNext;

        public TokenMiddleware(RequestDelegate next)
        {
            this.mNext = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            Console.WriteLine("Path = " + context.Request.Path);
            if (context.Request.Path.ToString().Contains("admin") && token != "12345678")
            {
                context.Response.StatusCode = 403;
                // await context.Response.WriteAsync("Token is invalid");
            }
            else
            {
                await mNext.Invoke(context);
            }
        }
    }
}