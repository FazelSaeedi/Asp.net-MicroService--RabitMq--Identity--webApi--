using Microservice.Common.Events;

namespace src.Microservice.Common.Events
{
    public interface IRejectedEvent : IEvent
    { 
        string Reason {get;}
        string Code {get;}
    }
}