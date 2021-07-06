using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace aspnet5basics.Middleware
{
    public class OrderRoutingMiddleware
    {
        private readonly RequestDelegate _next;
        public OrderRoutingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var sections = context.Request.Path.ToString().Split("/");
            if (sections.FirstOrDefault(section => !section.Trim().Equals("")) == "order")
            {
                context.Request.Path = "/index";
                if (sections.LastOrDefault() != null && int.TryParse(sections.Last(), out _))
                {
                    context.Request.QueryString = new QueryString($"?id={sections.Last()}");
                }
            }
            await _next.Invoke(context);
        }
    }
}