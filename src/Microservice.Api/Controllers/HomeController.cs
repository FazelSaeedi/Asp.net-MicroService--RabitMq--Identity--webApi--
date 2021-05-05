using Microsoft.AspNetCore.Mvc;

namespace src.Microservice.Api.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Get() => Content("Hello From Microservice Api ");
        
    }
}