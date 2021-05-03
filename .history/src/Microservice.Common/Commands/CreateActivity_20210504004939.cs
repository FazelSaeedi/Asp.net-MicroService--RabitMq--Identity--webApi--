using System;

namespace Microservice.Common.Commands
{
    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid UserId { get; set; }
        
    }
}