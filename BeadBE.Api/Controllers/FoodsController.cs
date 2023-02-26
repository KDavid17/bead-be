using Microsoft.AspNetCore.Mvc;

namespace BeadBE.Api.Controllers
{
    [Route("api/[controller]")]
    public class FoodsController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("hello");
        }
    }
}
