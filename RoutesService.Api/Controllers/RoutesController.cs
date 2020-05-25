using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using RoutesService.Domain;
using RoutesServices.Models;

namespace RoutesService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly IRouteService _routeService;
        public RoutesController(IRouteService routeService)
        {
            this._routeService = routeService;
        }

        /// <summary>
        /// Retrieve next arrival times per requested stop
        /// </summary>
        /// <param name="route"></param>
        /// <returns></returns>
        [EnableCors("Policy1")]
        [HttpPost("ArrivalTimes")]
        public IActionResult Post([FromBody] Route route)
        {
            try
            {
                var response = "";
                if (route != null)
                {
                    route.RequestedDateTime = DateTime.Now;
                    response = _routeService.RetrieveNextArrivalTimes(route);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}