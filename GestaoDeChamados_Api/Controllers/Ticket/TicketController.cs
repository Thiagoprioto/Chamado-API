using FluentValidation;
using GestaoDeChamados_Application.DTO.Ticket;
using GestaoDeChamados_Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeChamados_Api.Controllers.Ticket
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        private readonly IValidator<CreateTicketDto> _validator;

        public TicketController(ITicketService ticketService, IValidator<CreateTicketDto> validator)
        {
            _ticketService = ticketService;
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketAsync([FromBody] CreateTicketDto dto)
        {
            var validateTicket = await _validator.ValidateAsync(dto);

            if (!validateTicket.IsValid)
            {
                return BadRequest(validateTicket.Errors.Select(e => new
                {
                    Field = e.PropertyName,
                    Error = e.ErrorMessage
                }));
            }

            var createTicket = await _ticketService.CreateTicketAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = createTicket.Id }, createTicket);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var getAllTickets = await _ticketService.GetAllTicketsAsync();
            return Ok(getAllTickets);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return Ok(ticket);
        }

        [HttpPatch("{id:guid}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateTicketStatusRequest request)
        {
            await _ticketService.UpdateTicketStatusAsync(id, request.Status);
            return NoContent();
        }
    }
}