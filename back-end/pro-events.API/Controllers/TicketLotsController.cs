using Microsoft.AspNetCore.Mvc;
using pro_events.Application.DTO.Events;
using pro_events.Application.DTO.TicketLots;
using pro_events.Application.IServices;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace pro_events.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketLotsController : ControllerBase
    {
        private readonly ITicketLotService _service;
        public TicketLotsController(ITicketLotService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int eventId)
        {
            try
            {
                return Ok(_service.GetTicketLotByEventId(eventId));
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        /// <summary>
        /// Methods allows to insert and update a collection of TicketsLots.
        /// Send the model with Id and eventId setted to update, or send the model with EventId and none id to insert new.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     [
        ///         {
        ///           "id": 0,
        ///           "description": "string",
        ///           "value": 0,
        ///           "init": "2023-11-22T19:10:14.678Z",
        ///           "end": "2023-11-22T19:10:14.678Z",
        ///           "amount": 0,
        ///           "eventId": 0
        ///         }
        ///     ]
        ///
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TicketLotDto[] model)
        {
            try
            {
                if (await _service.SaveTicketLot(model))
                    return Ok(model);
                else
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Was not possible save the ticketlot. Please try again.");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Was not possible save the ticketlot. Please try again. Error: {ex.Message}");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] TicketLotDeleteDto model)
        {
            try
            {
                var rs = await _service.DeleteTicketLot(model.ticketLotId, model.eventId);
                if (rs)
                    return Ok(rs);
                else
                    return BadRequest($"Was not possible delete the ticketlot");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Was not possible delete the ticketlot. Error: {ex.Message}");
            }
        }
    }
}
