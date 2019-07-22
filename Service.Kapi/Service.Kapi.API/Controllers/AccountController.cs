using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Kapi.BLL.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Service.Kapi.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiVersionNeutral]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUsersService _userService;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(IUsersService userService, IJwtTokenService jwtTokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _jwtTokenService = jwtTokenService ?? throw new ArgumentNullException(nameof(jwtTokenService));
        }

        /// <summary>
        /// Generate sample token
        /// </summary>
        /// <returns>Generated token</returns>
        [HttpGet("generate")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Generated token")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GenerateToken()
        {            
            var token = await _jwtTokenService.GenerateToken();
            return Ok(token);
        }

        /// <summary>
        /// Validate sample token
        /// </summary>
        /// <param name="token">Token for validation</param>
        /// <returns>Token validation status</returns>
        [AllowAnonymous]
        [HttpPost("login")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Token validation status")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Bad request for missing or invalid parameter")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]       
        public async Task<IActionResult> Authenticate( string email,  string password) 
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("email ou password vazios");
            }
            /**
            var user = await _userService.Authenticate(email, password);

            if (user != null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                var token = await _jwtTokenService.GenerateToken();
                var response = new { user, token };
                return Ok(new { response });
            }
            var req = this.Request;
            return Ok(new { user, req });
            **/
            try
            {
                var user = await _userService.Authenticate(email, password);
                

                if ( user != null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
                {
                   var token = await _jwtTokenService.GenerateToken();
                   var response = new { user, token };
                   return Ok(user);
                }
                var req = this.Request;
                return Ok(new { user, req });

            }
                catch (Exception ex)
            {
               if (ex.Data.Count == 0)
                {
                    return NotFound(ex.Data);
                }

             return BadRequest(ex.Data);
            }
        }
    }
}
