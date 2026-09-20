
using GestaoDeChamados_Domain.Enum;

namespace GestaoDeChamados_Application.DTO.Ticket
{
    public record UpdateTicketDto(
        string Title,
        string Description,
        TicketsStatus Status
    );
}
