using HSCOP.Identity.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HSCOP.Identity.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public UserController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [AllowAnonymous]
        [HttpGet("GetToken")]
        public async Task<string> GetToken()
        {
            return _authenticateService.GetJWTToken();
        }
    }
}