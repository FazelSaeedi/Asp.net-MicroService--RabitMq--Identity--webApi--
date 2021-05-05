using System.Threading.Tasks;
using src.Microservice.Common.Events;
using System;

namespace src.Microservice.Api.Handlers
{
    public class ActivityCreateHandler : IEventHandler<ActivityCreated>
    {
        public async Task HandleAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Activity Created : {@event.Name}");
        }

    }
}