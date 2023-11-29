using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pro_events.API.Extensions;
using pro_events.Application.DTO.Events;
using pro_events.Application.IServices;
using pro_events.Persistence.Helpers;

namespace pro_events.API.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;
    private readonly IUserService _userService;

    public EventsController(IEventService eventService, IUserService userService)
    {
        _service = eventService;
       _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] PageParameters pageParams)
    {
        try
        {
            var ev = await _service.GetAllEventsAsync(pageParams, User.GetUserIdAsInt(), true);
            Response.AddPagination(ev.CurrentPage, ev.PageSize, ev.TotalCount, ev.TotalPages);
            return Ok(ev);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = "Error when getting events.", Error = @$"{ex.Message}" });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var ev = await _service.GetEventByIdAsync(User.GetUserIdAsInt(), id, true);
            return Ok(ev);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, new { Message = $"Error while getting events.", Error = ex.Message});
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] EventDto events)
    {
        try
        {
            events.UserId = User.GetUserIdAsInt();
            if (await _service.AddEvent(events))
                return Ok(events);
            else
                return BadRequest("Não foi possível adicionar o envento.");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao adicionar o evento. Erro: {ex.Message}");
        }
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EventDto events)
    {
        try
        {
            events.UserId = User.GetUserIdAsInt();
            if (await _service.UpdateEvent(events.Id, events))
                return Ok(events);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível atualizar o envento.");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível atualizar o envento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            if (await _service.DeleteEvent(User.GetUserIdAsInt(), id))
                return Ok();
            else
                return BadRequest($"Não foi possível remover o envento.");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Não foi possível remover o envento. Erro: {ex.Message}");
        }
    }
}
