
using GestaoDeChamados_Application.DTO.Ticket;
using GestaoDeChamados_Application.Exceptions;
using GestaoDeChamados_Application.Interface;
using GestaoDeChamados_Domain.Entity;
using GestaoDeChamados_Domain.Interface;

namespace GestaoDeChamados_Application.Service
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<TicketResponseDto> CreateTicketAsync(CreateTicketDto dto)
        {
            var ticket = new Ticket(dto.Title, dto.Description, dto.Priority);
            await _ticketRepository.CreateTicketAsync(ticket);
            return new TicketResponseDto(
                ticket.Id, 
                ticket.Title, 
                ticket.Description, 
                ticket.Priority, 
                ticket.Status,
                ticket.CreatedAt,
                ticket.UpdatedAt
            );
        }

        public async Task DeleteTicketAsync(Guid id)
        {
            var deletedTicket = await _ticketRepository.GetTicketByIdAsync(id);
            if (deletedTicket == null)
            {
                throw new NotFoundException("Chamado não encontrado");
            }

            await _ticketRepository.DeleteTicketAsync(deletedTicket.Id);
        }

        public async Task<IEnumerable<TicketResponseDto>> GetAllTicketsAsync()
        {
            var tickets = await _ticketRepository.GetAllTicketsAsync();
            return tickets.Select(t => new TicketResponseDto(
                t.Id,
                t.Title,
                t.Description,
                t.Priority,
                t.Status,
                t.CreatedAt,
                t.UpdatedAt
            ));
        }

        public async Task<TicketResponseDto> GetTicketByIdAsync(Guid id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                throw new NotFoundException("Chamado não encontrado");
            }

            return new TicketResponseDto(
                ticket.Id,
                ticket.Title,
                ticket.Description,
                ticket.Priority,
                ticket.Status,
                ticket.CreatedAt,
                ticket.UpdatedAt
            );
        }

        public async Task<TicketResponseDto> UpdateTicketAsync(Guid id, UpdateTicketDto ticket)
        {
            var existingTicket = await _ticketRepository.GetTicketByIdAsync(id);
            if (existingTicket == null)
            {
                throw new NotFoundException("Chamado não encontrado");
            }
            existingTicket.UpdateDetails(ticket.Title, ticket.Description);
            existingTicket.ChangeStatus(ticket.Status);

            await _ticketRepository.UpdateTicketAsync(existingTicket);

            return new TicketResponseDto(
                existingTicket.Id,
                existingTicket.Title,
                existingTicket.Description,
                existingTicket.Priority,
                existingTicket.Status,
                existingTicket.CreatedAt,
                existingTicket.UpdatedAt
            );
        }
    }
}
