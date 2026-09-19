using GestaoDeChamados_Application.DTO.Ticket;

namespace GestaoDeChamados_Application.Interface
{
    public interface ITicketService
    {
        Task<TicketResponseDto> GetTicketByIdAsync(Guid id);
        Task<IEnumerable<TicketResponseDto>> GetAllTicketsAsync();
        Task<TicketResponseDto> CreateTicketAsync(CreateTicketDto ticket);
        Task<TicketResponseDto> UpdateTicketAsync(CreateTicketDto ticket);
        Task DeleteTicketAsync(Guid id);
    }
}
