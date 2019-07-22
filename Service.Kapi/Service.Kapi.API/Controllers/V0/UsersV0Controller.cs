using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Kapi.API.Models;
using Service.Kapi.BLL.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Service.Kapi.API.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("0.9", Deprecated = true)]
    [ApiController]
    public class UsersV0Controller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        public UsersV0Controller(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        /// <summary>
        /// Get users list
        /// </summary>       
        /// <param name="limit">Items count</param>
        /// <returns></returns>
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<User>), Description = "Returns finded users array")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetUsersV0ListAsync([FromQuery] int limit = 50)
        {
            if(limit == 0)
            {
                return BadRequest();
            }

            var result = await _usersService.GetUsersListAsync(1, limit);
            return Ok(_mapper.Map<IEnumerable<User>>(result));
        }
    }
}
