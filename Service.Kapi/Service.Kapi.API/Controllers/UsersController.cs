using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Kapi.API.Models;
using Service.Kapi.API.Swagger;
using Service.Kapi.BLL.Contracts;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Service.Kapi.API.Controllers
{
    // [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUsersService _usersService;

        /// <summary>
        /// Users db api
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="usersService"></param>
        public UsersController(IMapper mapper, IUsersService usersService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Returns created user</returns>
        [HttpPost("")]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(UserModelExample))]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(User), Description = "Returns created user")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> CreateUserAsync([FromBody] User user)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var result = await _usersService.CreateUserAsync(_mapper.Map<BLL.Models.User>(user));
                return Created($"{result}", _mapper.Map<User>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

           
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Returns finded user</returns>
        [HttpGet("{id}")]        
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(User), Description = "Returns finded user")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(UserModelExample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid user id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetUserAsync([FromRoute] Guid id) 
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _usersService.GetUserAsync(id);
            return Ok(_mapper.Map<User>(result));
        }

        /// <summary>
        /// Update existing user
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="user">User parameters</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerRequestExample(typeof(User), typeof(UserModelExample))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid user object")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] User user)
        {
            if (id == Guid.Empty || !ModelState.IsValid)
            {
                return BadRequest();
            }

            user.Id = id;
            var result = await _usersService.UpdateUserAsync(_mapper.Map<BLL.Models.User>(user));
            return Ok();
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid user id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            var result = await _usersService.DeleteUserAsync(id);
            return Ok();
        }

        /// <summary>
        /// Get users list
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<User>), Description = "Returns finded users array")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetUsersListAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            if(pageNumber==0 || pageSize == 0)
            {
                return BadRequest();
            }

            var result = await _usersService.GetUsersListAsync(pageNumber, pageSize);
            return Ok(_mapper.Map<IEnumerable<User>>(result));
        }
    }
}
