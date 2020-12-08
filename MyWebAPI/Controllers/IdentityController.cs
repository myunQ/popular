using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace MyWebAPI.Controllers
{
    [Authorize]
    [Route("identity")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            AuthenticateResult authResult = await HttpContext.AuthenticateAsync();
    
            return new JsonResult(new
            {
                User = from c in User.Claims select new { c.Type, c.Value },
                Authent = from p in authResult.Properties.Items select new { p.Key, p.Value}
            });
        }

        
        [HttpGet("logout")]
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
    }
}
