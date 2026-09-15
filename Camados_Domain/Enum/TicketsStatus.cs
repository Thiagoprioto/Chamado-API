namespace Chamados_Domain.Enum
{
    public enum TicketsStatus
    {
        // Normally fluent Ticket progress
        Open = 0,
        InProgress = 1,
        Closed = 2,

        // Status if the Ticket is not suposed to be completed

        Canceled = 3,
        ClosedWithoutSolution = 4
    }
}