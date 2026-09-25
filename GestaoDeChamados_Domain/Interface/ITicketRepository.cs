using GestaoDeChamados_Domain.Entity;

namespace GestaoDeChamados_Domain.Interface
{
    public interface ITicketRepository
    {
        Task<Ticket?> GetTicketByIdAsync(Guid id);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(Ticket ticket);
    }
}
