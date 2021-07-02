using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace aspnet5basics
{
    using Host = Microsoft.Extensions.Hosting.Host;
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                        {
                            serverOptions.ListenLocalhost(8080);
                        })
                        .UseStartup<Startup>();
                });
    }
}