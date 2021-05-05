using System.Threading.Tasks;
using Microservice.Common.Commands;
using Microservice.Common.Events;
using RawRabbit;
using RawRabbit.Pipe;
using src.Microservice.Common.Events;

namespace src.Microservice.Common.RabbitMq
{
    public static class Extensions
    {
       public static Task WithCommandHandlerAsync<TCommand> (this IBusClient bus,
        ICommandHandler<TCommand> handler) where TCommand : ICommand =>
        bus.SubscribeAsync<TCommand> (msg => handler.HandleAsync(msg) ,
        ctx => ctx.UseConsumerConfiguration (cfg =>
          cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TCommand> ()))
        ));

    public static Task WithEventHandlerAsync<TEvent> (this IBusClient bus,
        IEventHandler<TEvent> handler) where TEvent : IEvent =>
      bus.SubscribeAsync<TEvent> (msg => handler.HandleAsync (msg),
        ctx => ctx.UseConsumerConfiguration (cfg =>
          cfg.FromDeclaredQueue (q => q.WithName (GetQueueName<TEvent> ()))
        ));

    private static string GetQueueName<T> () => $"{System.Reflection.Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
    }
}



