using FluentAssertions;
using GestaoDeChamados_Application.Service;
using GestaoDeChamados_Domain.Entity;
using GestaoDeChamados_Domain.Enum;
using GestaoDeChamados_Domain.Interface;
using Moq;

namespace GestaoDeChamados_Tests;

public class TicketServiceTests
{
    private readonly Mock<ITicketRepository> _repositoryMock;
    private readonly TicketService _service;

    public TicketServiceTests()
    {
        _repositoryMock = new Mock<ITicketRepository>();
        _service = new TicketService(_repositoryMock.Object);
    }

    [Fact]
    public async Task UpdateStatusAsync_ShouldThrowKeyNotFoundException_WhenTicketDoesNotExist()
    {
        // Arrange - Simula o banco retornando null
        var ticketId = Guid.NewGuid();
        _repositoryMock
            .Setup(repo => repo.GetTicketByIdAsync(ticketId))
            .ReturnsAsync((Ticket?)null);

        // Act
        Func<Task> act = async () => await _service.UpdateTicketStatusAsync(ticketId, TicketsStatus.InProgress);

        // Assert
        await act.Should()
         .ThrowAsync<KeyNotFoundException>()
         .WithMessage($"Ticket com o ID {ticketId} não foi encontrado.");
    }
}