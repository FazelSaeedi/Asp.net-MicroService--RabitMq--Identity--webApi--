namespace Microservice.Common.Events
{
    public interface IAuthenticatedEvent : IEvent
    {
         Guid UserId { get; set; }
    }
}