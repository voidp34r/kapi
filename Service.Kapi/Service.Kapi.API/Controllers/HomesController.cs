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
    [Authorize]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/homes")]
    [ApiVersion("1.0")]
    [ApiController]
    public class HomesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHomesService _homesService;

        /// <summary>
        /// Homes db api
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="homesService"></param>
        public HomesController(IMapper mapper, IHomesService homesService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _homesService = homesService ?? throw new ArgumentNullException(nameof(homesService));
        }

        /// <summary>
        /// Create a new home
        /// </summary>
        /// <param name="home"></param>
        /// <returns>Returns created home</returns>           
        [HttpPost("")]
        [SwaggerResponseExample((int)HttpStatusCode.Created, typeof(HomeModelExample))]
        [SwaggerResponse((int)HttpStatusCode.Created, Type = typeof(Home), Description = "Returns created home")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> CreateHomeAsync([FromBody] Home home)
        { 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.IsValid);
            }

            try
            {
                var result = await _homesService.CreateHomeAsync(_mapper.Map<BLL.Models.Home>(home));
                return Created($"{result}", _mapper.Map<Home>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get home by id
        /// </summary>
        /// <param name="id">Home Id</param>
        /// <returns>Returns finded home</returns>
        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Home), Description = "Returns finded home")]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(HomeModelExample))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid home id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetHomeAsync([FromRoute] Guid id) 
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var result = await _homesService.GetHomeAsync(id);
                return Ok(_mapper.Map<Home>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }

        /// <summary>
        /// Update existing home
        /// </summary>
        /// <param name="id">Home id</param>
        /// <param name="home">Home parameters</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerRequestExample(typeof(Home), typeof(HomeModelExample))]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid home object")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> UpdateHomeAsync([FromRoute] Guid id, [FromBody] Home home)
        {
            if (id == Guid.Empty || !ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                home.Id = id;
                var result = await _homesService.UpdateHomeAsync(_mapper.Map<BLL.Models.Home>(home));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Delete home
        /// </summary>
        /// <param name="id">Home id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = "Returns 200")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid home id")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> DeleteHomeAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            try
            {
                var result = await _homesService.DeleteHomeAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Get homes list
        /// </summary>
        /// <param name="pageNumber">Page number</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        [HttpGet("")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(IEnumerable<Home>), Description = "Returns finded homes array")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Missing or invalid pageNumber or pageSize")]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, Description = "Unexpected error")]
        public async Task<IActionResult> GetHomesListAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            if(pageNumber==0 || pageSize == 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await _homesService.GetHomesListAsync(pageNumber, pageSize);
                return Ok(_mapper.Map<IEnumerable<Home>>(result));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
