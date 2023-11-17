using Microsoft.AspNetCore.Mvc;
using pro_events.API.Models;

namespace pro_events.API.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : ControllerBase
{
	private readonly ILogger<EventsController> _logger;

	private readonly IEnumerable<Events> _events = new Events[]
	{
			new() {
				Id = 1,
				Location = "Local A",
				EventDate = DateTime.Now,
				Subject = "Evento 1",
				Amount = 100,
				Number = "ABC123",
				ImgUrl = "https://example.com/image1.jpg"
			},
			new() {
				Id = 2,
				Location = "Local B",
				EventDate = DateTime.Now.AddDays(7),
				Subject = "Evento 2",
				Amount = 150,
				Number = "XYZ456",
				ImgUrl = "https://example.com/image2.jpg"
			}
			,
			new() {
				Id = 3,
				Location = "Local C",
				EventDate = DateTime.Now.AddDays(7),
				Subject = "Evento 3",
				Amount = 90,
				Number = "XYZ789",
				ImgUrl = "https://example.com/image3.jpg"
			}
	};

	public EventsController(ILogger<EventsController> logger)
	{
		_logger = logger;
	}

	[HttpGet(Name = "GetEvents")]
	public IEnumerable<Events> Get()
	{
		return _events;
	}

	[HttpPost]
	public IActionResult Post([FromBody] Events events)
	{
		try
		{
			_events.Append(events);
			return Ok(events);
		}
		catch (Exception ex)
		{
			return BadRequest(ex);
		}
	}
}
