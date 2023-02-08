using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("[controller]")]
    public class HealthController : Controller
    {
        [HttpGet("")]
        public string GetHealth()
        {
            return "Success: DemoProject ";
        }
    }
}
