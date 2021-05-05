using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Common.Commands;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using src.Microservice.Common.Services;

namespace Microservice.Services.Activities
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            ServiceHost.Create<Startup>(args)
            .UseRabbitMq()
            .SubscribeToCommand<CreateActivity>()
            .Build()
            .Run();

        }

    }
}
