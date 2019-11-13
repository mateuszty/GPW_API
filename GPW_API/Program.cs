using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GPW_API.Core;
using GPW_API.Core.BackgrServices;
using GPW_API.DataAccess;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GPW_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((services) =>
                {
                    services.AddHostedService<BackgroundRefresh>();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //webBuilder.ConfigureKestrel(serverOptions =>
                    //{
                    //    serverOptions.Listen(System.Net.IPAddress.Parse("127.0.0.1"), 5001);
                    //})
                    webBuilder.UseStartup<Startup>();
                });
    }
}
