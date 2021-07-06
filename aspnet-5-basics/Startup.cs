using aspnet5basics.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspnet5basics
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyDependency, MyDependency>();
            services.AddRazorPages().WithRazorPagesRoot("/Pages");;
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMiddleware<OrderRoutingMiddleware>();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            
            app.UseMiddleware<ErrorHandlingMiddleware>();
            // app.UseMiddleware<AuthenticationMiddleware>();
            app.UseMiddleware<TokenMiddleware>();

            app.Map("/products", (appBuilder => {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>Products Page</h1>");
                });
            }));

            app.Map("/about", (appBuilder => {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>About</h1>");
                });
            }));

            app.Map("/admin", (admin => {
                admin.Map("/users", (appBuilder => {
                    appBuilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("<h1>Users list</h1>");
                    });
                }));
                admin.Map("/analytics", (appBuilder => {
                    appBuilder.Run(async (context) =>
                    {
                        await context.Response.WriteAsync("<h1>Analytics</h1>");
                    });
                }));
                admin.Run(async (context) =>
                {
                    await context.Response.WriteAsync("<h1>Admin</h1>");
                });
            }));

            /* app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Page Not Found");
            }); */
            
            app.UseMiddleware<RoutingMiddleware>();
        }
    }
}