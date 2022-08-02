using Microsoft.AspNetCore.Mvc;

namespace iTestApi.Controllers
{
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult ItWorks()
        {
            return Ok(new
            {
                DoesItWork = "Yes",
                AppName = "iTestApi",
                Dev = "Enea",
                Hotel = "Trivago"
            });
        }
    }
}