﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using IdentityServer4.Services;

namespace MyIdentityServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        

        [HttpGet("error")]
        public async Task<IActionResult> Error(string errorId, [FromServices]IIdentityServerInteractionService interaction)
        {
            var message = await interaction.GetErrorContextAsync(errorId);
            

            return new ObjectResult(message);
        }
    }
}
