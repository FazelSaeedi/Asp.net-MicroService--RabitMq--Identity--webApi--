using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace src.Microservice.Common.Services
{
    public class ServiceHost : IServiceHost
    {

        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run () => _webHost.Run();


        public static HostBuilder Create<TSturtup>(string[] args) where TSturtup : class
        {
            Console.Title = typeof(TSturtup).Namespace;
            var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

            var webHostBuilder = WebHost.CreateDefaultBuilder(args)
            .UseConfiguration(config)
            .UseStartup<TSturtup>();

            return new HostBuilder(webHostBuilder.Build());
        }
    }
}