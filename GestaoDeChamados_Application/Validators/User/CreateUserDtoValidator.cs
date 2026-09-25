using FluentValidation;
using GestaoDeChamados_Application.DTO.User;

namespace GestaoDeChamados_Application.Validators.User
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .Length(1, 100).WithMessage("O nome deve ter no máximo 100 caracteres.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser um endereço de email válido.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .Matches(@"[0-9]").WithMessage("A senha deve conter pelo menos um número.")
                .Length(6, 16).WithMessage("A senha deve ter entre 6 e 16 caracteres.");
        }
    }
}
