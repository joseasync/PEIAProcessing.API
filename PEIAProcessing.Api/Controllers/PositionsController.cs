using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PEIAProcessing.Domain.Common;
using PEIAProcessing.Domain.Entities;
using PEIAProcessing.Domain.Interfaces;
using PEIAProcessing.Service.Validators;

namespace PEIAProcessing.Api.Controllers
{
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly ILogger<PositionsController> _logger;
        private readonly IServiceDomain<Position> _service;

        public PositionsController(ILogger<PositionsController> logger, IServiceDomain<Position> service)
        {
            _logger = logger;
            _service = service;
        }

        //[ProducesResponseType(200)]
        //[HttpGet(RoutesManagement.Position.)]
        //public async Task<IActionResult> Search([FromQuery]PositionFilter positionFilter)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"GetPositions requested"); //log optional
        //        var result = await _service.Search(positionFilter);
        //        return Ok(result);
        //    }
        //    catch (Exception e)
        //    {
        //        _logger.LogError(e, "Search Error");
        //        return StatusCode(500, "Internal Error (check logs)");
        //    }

        //}

        [ProducesResponseType(200)]
        [HttpGet(RoutesManagement.Position.GetPositions)]
        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [ProducesResponseType(200)]
        [HttpGet(RoutesManagement.Position.RoutePositionById)]
        public async Task<IActionResult> GetPosition(int id)
        {
            try
            {
                _logger.LogInformation($"Get by ID:{id} requested");//log optional

                if (!ModelState.IsValid || id <= 0)
                    return NotFound("Invalid ID");

                var result = _service.Get(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "GetPosition Error");
                return StatusCode(500, "Internal Error (check logs)");

            }
        }

        [ProducesResponseType(201)]
        [HttpPost(RoutesManagement.Position.RoutePosition)]
        public IActionResult Post([FromBody] Position item)
        {
            try
            {
                _service.Post<PositionValidator>(item);

                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [HttpPut(RoutesManagement.Position.RoutePosition)]
        public async Task<IActionResult> Put([FromBody] Position item)
        {

            try
            {
                //_logger.LogInformation($"Put by ID:{id} requested");//log optional

                if (!ModelState.IsValid)
                    return NotFound("Invalid ID");

                _service.Put<PositionValidator>(item);
                return new ObjectResult(item.Id);

                ////Due W3 documentation, PUT should post in second option.
                //var created = await _service.PostPosition(positionToPut);
                //if (created)
                //    return StatusCode(201, "Success");

                //return BadRequest("Internal Error (check logs)");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Put Error");
                return StatusCode(500, "Internal Error (check logs)");

            }
        }

        [ProducesResponseType(200)]
        [HttpPatch(RoutesManagement.Position.RoutePosition)]
        public async Task<IActionResult> Patch(int id, Position positionToPatch)
        {
            //try
            //{
            //    _logger.LogInformation($"Patch by ID:{id} requested");//log optional

            //    if (!ModelState.IsValid || id <= 0)
            //        return NotFound("Invalid ID");


            //    var updated = await _service.patch(id, positionToPatch);
            //    if (updated)
            //        return Ok("Success");


            //    return NoContent();
            //}
            //catch (Exception e)
            //{
            //    _logger.LogError(e, "Patch Error");
            //    return StatusCode(500, "Internal Error (check logs)");

            //}
            return null;
        }

        [ProducesResponseType(200)]
        [HttpDelete(RoutesManagement.Position.RoutePositionById)]
        public async Task<IActionResult> DeletePosition(int id)
        {
            try
            {
                _logger.LogInformation($"Delete ID:{id} requested");//log optional

                if (!ModelState.IsValid || id <= 0)
                    return NotFound("Invalid ID");

                _service.Delete(id);
                return new NoContentResult();



                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "DeletePosition Error");
                return StatusCode(500, "Internal Error (check logs)");

            }
        }

    }
}
