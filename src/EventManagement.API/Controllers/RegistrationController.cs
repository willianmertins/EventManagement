using EventManagement.Application.DTOs;
using EventManagement.Application.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RegistrationController(RegisterToEventUseCase registerToEventUseCase, ListUserEventsUseCase listUserEventsUseCase) : ControllerBase
    {
        private readonly RegisterToEventUseCase _registerToEventUseCase = registerToEventUseCase;
        private readonly ListUserEventsUseCase _listUserEventsUseCase = listUserEventsUseCase;

        [HttpPost]
        public async Task<IActionResult> RegisterToEventAsync([FromBody] RegisterToEventRequest request)
        {
            try
            {
                var response = await _registerToEventUseCase.ExecuteAsync(request, User);
                return Ok(response);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("my-events")]
        public async Task<IActionResult> ListUserEvents()
        {
            var events = await _listUserEventsUseCase.ExecuteAsync(User);
            return Ok(events);
        }
    }
}
