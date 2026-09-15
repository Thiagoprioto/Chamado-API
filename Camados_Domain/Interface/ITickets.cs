
using Chamados_Domain.Entity;

namespace Chamados_Domain.Interface
{
    public interface ITickets
    {
        Task<Ticket> GetTicketByIdAsync(Guid id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket> UpdateTicketAsync(Ticket ticket);
        Task<Ticket> DeleteTicketAsync(Guid id);
    }
}
