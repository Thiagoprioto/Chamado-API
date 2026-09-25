using FluentAssertions;
using GestaoDeChamados_Domain.Entity;
using GestaoDeChamados_Domain.Enum;

namespace GestaoDeChamados_Tests;

public class TicketTests
{
    [Fact]
    public void UpdateStatus_ShouldThrowInvalidOperationException_WhenTicketIsAlreadyCanceled()
    {
        var ticket = new Ticket("Erro no Sistema", "Descrição do problema", PriorityTicketStatus.Normal);
        ticket.UpdateStatus(TicketsStatus.Canceled); // Cancela o chamado primeiro

        Action act = () => ticket.UpdateStatus(TicketsStatus.InProgress);

        act.Should()
           .Throw<InvalidOperationException>()
           .WithMessage("Não é possível alterar o status de um chamado que já está cancelado.");
    }

    [Fact]
    public void UpdateStatus_ShouldUpdateStatusSuccessfully_WhenTicketIsOpen()
    {
        var ticket = new Ticket("Erro no Sistema", "Descrição do problema", PriorityTicketStatus.Low);

        ticket.UpdateStatus(TicketsStatus.InProgress);

        ticket.Status.Should().Be(TicketsStatus.InProgress);
    }
}