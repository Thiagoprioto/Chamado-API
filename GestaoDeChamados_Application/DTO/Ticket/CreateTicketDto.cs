using GestaoDeChamados_Domain.Enum;

namespace GestaoDeChamados_Application.DTO.Ticket
{
    public record CreateTicketDto(
        string Title,
        string Description,
        PriorityTicketStatus Priority
    );
}