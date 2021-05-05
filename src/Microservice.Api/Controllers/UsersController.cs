using System.Threading.Tasks;
using Microservice.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace src.Microservice.Api.Controllers
{
    [Route("[controller]")]
    public class UsersController : Controller
    {
         private readonly IBusClient _busClient ;

        public UsersController(IBusClient busClient)
        {
            _busClient = busClient;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Post ([FromBody]CreateUser command)
        {
            await _busClient.PublishAsync(command);
            return Accepted();
        }
    }
}