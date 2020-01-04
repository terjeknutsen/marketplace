using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using static System.Environment;
using static System.Reflection.Assembly;

namespace Marketplace
{
    public class Program
    {
        static Program() => CurrentDirectory = Path.GetDirectoryName(GetEntryAssembly().Location); 
        public static void Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            CreateHostBuilder(configuration).Build().Run();
        }

        private static IConfiguration BuildConfiguration(string[] args)
        => new ConfigurationBuilder()
            .SetBasePath(CurrentDirectory)
            .Build();

        public static IWebHostBuilder CreateHostBuilder(IConfiguration configuration)
        => new WebHostBuilder()
            .UseStartup<Startup>()
            .UseConfiguration(configuration)
            .ConfigureServices(s => s.AddSingleton(configuration))
            .UseContentRoot(CurrentDirectory)
            .UseKestrel();
            
            //Host.CreateDefaultBuilder(args)
            //    .ConfigureWebHostDefaults(webBuilder =>
            //    {
            //        webBuilder.UseStartup<Startup>();
            //    });
    }
}
