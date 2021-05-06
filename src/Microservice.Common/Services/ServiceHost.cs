using System;
using Microservice.Common.Commands;
using Microservice.Common.Events;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using src.Microservice.Common.Events;
using src.Microservice.Common.RabbitMq;

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
             .UseUrls("http://*:5050")
            .UseConfiguration(config)
            .UseStartup<TSturtup>()
            .UseDefaultServiceProvider(option =>
            {
                option.ValidateScopes = false;
            }); ;

            return new HostBuilder(webHostBuilder.Build());
        }

        public abstract class BuilderBase
        {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private  IBusClient _bus ;
            private readonly IWebHost _webHost;

            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UseRabbitMq()
            {
                _bus = (IBusClient) _webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost , _bus );
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
            
        }

        public class BusBuilder : BuilderBase
        {

            private  IBusClient _bus ;
            private readonly IWebHost _webHost;

            public BusBuilder(IWebHost webHost , IBusClient busClient)
            {
                _webHost = webHost;
                _bus = busClient ;
            }


            public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
            {
                var handler = (ICommandHandler<TCommand>) _webHost.Services
                .GetService(typeof(ICommandHandler<TCommand>));

                _bus.WithCommandHandlerAsync(handler);

                return this;
            }

            public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
            {
                 var handler = (IEventHandler<TEvent>) _webHost.Services
                 .GetService(typeof(IEventHandler<TEvent>));

                _bus.WithEventHandlerAsync(handler);

                return this;
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
    }
}