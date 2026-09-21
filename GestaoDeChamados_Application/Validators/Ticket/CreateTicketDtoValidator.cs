

using FluentValidation;
using GestaoDeChamados_Application.DTO.Ticket;

namespace GestaoDeChamados_Application.Validators.Ticket
{
    public class CreateTicketDtoValidator : AbstractValidator<CreateTicketDto>
    {
        public CreateTicketDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .Length(1, 100).WithMessage("O título deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .Length(1, 1000).WithMessage("A descrição deve ter no máximo 1000 caracteres.");
            RuleFor(x => x.Priority)
                .IsInEnum().WithMessage("A prioridade deve ser um valor válido.");
        }
    }
}
