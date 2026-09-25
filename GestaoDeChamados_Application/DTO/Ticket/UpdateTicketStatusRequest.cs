using GestaoDeChamados_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoDeChamados_Application.DTO.Ticket
{
    public record UpdateTicketStatusRequest(TicketsStatus Status);
}
