namespace Shop.Web1
{
    using Data;
    using Microsoft.AspNetCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            RunSeeding(host);
            host.Run();
        }

        private static void RunSeeding(IWebHost host)
        {
            var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<SeedDB>();
                seeder.SeedAsync().Wait();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
.UseStartup<Startup>();
        }
    }
}

//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args)
//        {
//            return Host.CreateDefaultBuilder(args)
//.ConfigureWebHostDefaults(webBuilder =>
//{
//    webBuilder.UseStartup<Startup>();
//});
//        }
//    }
//}
