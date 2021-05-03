using System.Threading.Tasks;
using Microservice.Common.Events;

namespace src.Microservice.Common.Events
{
    public interface IEventHandler<in T> where T: IEvent
    {
        Task HandleAsync(T @event);
    }
}