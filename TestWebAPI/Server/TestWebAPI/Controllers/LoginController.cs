using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestWebAPI.DTOS.Person;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IPersonService _personService;

        public LoginController(IPersonService userService)
        {
            _personService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<LoginRespone> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response =  _personService.Login(request);

                if (response == null)
                    return BadRequest();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }
    }
}
