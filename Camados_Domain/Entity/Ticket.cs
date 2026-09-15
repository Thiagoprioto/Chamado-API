using Chamados_Domain.Enum;

namespace Chamados_Domain.Entity
{
    public class Ticket
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public PriorityTicketStatus Priority { get; private set; }
        public TicketsStatus Status { get; private set; } = TicketsStatus.Open;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }

        public Ticket(string title, string description, PriorityTicketStatus priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            Status = TicketsStatus.Open;
        }

        public void UpdateDetails(string title, string description, PriorityTicketStatus priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangeStatus(TicketsStatus newStatus)
        {
            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}