using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Figgle;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Newbe.LiveCaptioning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(
                FiggleFonts.Standard.Render("Newbe.LiveCaptioning"));
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}