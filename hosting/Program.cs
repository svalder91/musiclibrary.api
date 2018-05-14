using System.IO;
using Demo.MusicLibrary.Api.Host;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace hosting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel()
                .UseIISIntegration()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();
    }
}
