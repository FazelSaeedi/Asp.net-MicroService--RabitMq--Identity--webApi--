using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Services.Activities.Controllers

{

    [Produces("application/json")]
    [Route("api/Home")]
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Get() => Content("Hellow From Microservice.Services.Activities.Controllers"); 
        
    }
}
