using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homecooked.Api.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet("secure")]
        [Authorize]
        public IActionResult SecureEndpoint()
        {
            return Ok("You are authenticated");
        }

        [Authorize(Roles = "ADMIN")]
        [HttpGet("admin")]
        public IActionResult AdminOnly()
        {
            return Ok("Admin access granted");
        }

        [Authorize(Roles = "CHEF")]
        [HttpGet("chef")]
        public IActionResult ChefOnly()
        {
            return Ok("Chef access granted");
        }

        [Authorize(Roles = "ADMIN,CHEF")]
        [HttpGet("admin-chef")]
        public IActionResult AdminChef()
        {
            return Ok("Admin or Chef access");
        }



    }
}
