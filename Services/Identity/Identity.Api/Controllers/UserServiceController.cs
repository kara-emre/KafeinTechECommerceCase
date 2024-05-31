using Identity.Api.Model.Dtos;
using Identity.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserServiceController : ControllerBase
    {
        [HttpPost]
        [Route("Login")]
        [ProducesResponseType(typeof(UserLoginResponse), (int)HttpStatusCode.OK)]
        public ActionResult<UserLoginResponse> CreateProduct([FromBody] UserLoginRequest userLoginRequest)
        {
            try
            {
                return Ok(UserService.UserCheckLogin(userLoginRequest));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
