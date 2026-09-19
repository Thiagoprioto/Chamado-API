using GestaoDeChamados_Domain.Entity;

namespace GestaoDeChamados_Domain.Interface
{
    public interface ITicketRepository
    {
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<Ticket> DeleteTicketAsync(Guid id);
    }
}
