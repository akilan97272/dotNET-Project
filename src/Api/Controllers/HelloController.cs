using Microsoft.AspNetCore.Mvc;

namespace AICalendar.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello, Swagger!";
    }
}
