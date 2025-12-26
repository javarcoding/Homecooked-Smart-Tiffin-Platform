using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homecooked.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            return Ok("JWT Token is valid");
        }
    }
}
