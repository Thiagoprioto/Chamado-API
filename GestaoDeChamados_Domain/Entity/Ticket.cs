using GestaoDeChamados_Domain.Enum;

namespace GestaoDeChamados_Domain.Entity
{
    public class Ticket : BaseEntity
    {

        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public PriorityTicketStatus Priority { get; private set; }
        public TicketsStatus Status { get; private set; } = TicketsStatus.Open;

        public Ticket(string title, string description, PriorityTicketStatus priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = TicketsStatus.Open;
        }

        public void UpdateDetails(string title, string description)
        {
            Title = title;
            Description = description;
            UpdateTimestamp();
        }

        public void ChangeStatus(TicketsStatus newStatus)
        {
            Status = newStatus;
            UpdateTimestamp();
        }

        public void UpdateStatus(TicketsStatus newStatus)
        {
            if (Status == TicketsStatus.Canceled)
            {
                throw new InvalidOperationException("Não é possível alterar o status de um chamado que já está cancelado.");
            }

            if (Status == TicketsStatus.Closed && newStatus == TicketsStatus.Open)
            {
                throw new InvalidOperationException("Não é possível reabrir um chamado que já foi concluído.");
            }

            Status = newStatus;
        }
    }
}