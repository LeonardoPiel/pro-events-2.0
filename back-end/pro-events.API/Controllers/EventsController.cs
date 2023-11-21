using Microsoft.AspNetCore.Mvc;
using pro_events.API.Persistence;
using pro_events.Application.IServices;
using pro_events.Domain;

namespace pro_events.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
    private readonly IEventService _service;
    public EventsController(IEventService eventService)
    {
        _service = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            return Ok(_service.GetEvents(true));
        }
        catch (Exception ex)
        {
            return BadRequest($" Erro ao recuperar eventos. Erro: {ex.Message}");
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(_service.GetEventById(id, true));
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o evento. Erro: {ex.Message}");
        }
    }
    [HttpGet("{s}/subject")]
    public async Task<IActionResult> Get([FromQuery] string s)
    {
        try
        {
            return Ok(_service.GetEventsBySubject(s, true));
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao recuperar o evento. Erro: {ex.Message}");
        }
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Event events)
    {
        try
        {
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
    public async Task<IActionResult> Put([FromBody] Event events)
    {
        try
        {
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
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        try
        {
            if (await _service.DeleteEvent(id))
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
