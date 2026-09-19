using GestaoDeChamados_Domain.Enum;
using System.Reflection.Metadata;

namespace GestaoDeChamados_Application.DTO.Ticket
{
    public record CreateTicketDto(
        string Title,
        string Description,
        PriorityTicketStatus Priority
    );
}
