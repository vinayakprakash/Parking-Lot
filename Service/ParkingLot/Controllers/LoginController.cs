using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingLotApi.Service;

namespace ParkingLotApi.Controllers
{
    [Route("api/parkinglot/profile")]
    [ApiController]
    [Filters.Authorization]
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Login()
        {
            return Ok(_loginService.GetUserRole(HttpContext.Request.Headers["token"]));
        }
    }
}