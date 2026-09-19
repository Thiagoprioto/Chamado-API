using GestaoDeChamados_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeChamados_Application.DTO.Ticket
{
    public record TicketResponseDto(
        Guid Id,
        string Title,
        string Description,
        PriorityTicketStatus Priority,
        TicketsStatus Status,
        DateTime CreatedAt,
        DateTime? UpdatedAt
    );
}
