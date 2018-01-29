using System.Security.Principal;
using jwt_auth_service.Filters;
using jwt_auth_service.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace jwt_auth_service.Controllers
{
    [AuthorizeRoles(Role.TeamRole)]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly JwtHelper _jwtHelper;

        public AuthController(JwtHelper jwtHelper)
        {
            this._jwtHelper = jwtHelper;
        }


        [HttpGet("Authenticate")]
        public IActionResult Authenticate()
        {
            var user = WindowsIdentity.GetCurrent();
            var token = _jwtHelper.GenerateJwtToken(user);
            return Json(token);
        }

        // TODO: authorize on valid bearer token
        [HttpGet("IsAuthorized")]
        public IActionResult IsAuthorized()
        {
            var token = Request.Headers["authorization: Bearer"];
            //var isValidToken = _jwtHelper.IsJwtValid(token);
            return new OkResult();
        }
    }
}
