using EventManagement.Application.DTOs;
using EventManagement.Application.UseCases;
using EventManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController(CreateEventUseCase createEventUseCase, IEventRepository eventRepository) : ControllerBase
    {
        private readonly CreateEventUseCase _createEventUseCase = createEventUseCase ?? throw new ArgumentNullException(nameof(createEventUseCase));
        private readonly IEventRepository _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventRequest request)
        {
            try
            {
                var response = await _createEventUseCase.ExecuteAsync(request, User);
                return CreatedAtAction(nameof(GetEventById), new { id = response.Id }, response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetEventById(Guid id)
        {
            var ev = await _eventRepository.GetByIdAsync(id);
            if (ev is null)
                return NotFound($"Evento com id {id} não encontrado.");

            return Ok(ev);
        }
    }
}
