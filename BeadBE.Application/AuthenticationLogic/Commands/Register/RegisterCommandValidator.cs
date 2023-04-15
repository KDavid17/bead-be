using FluentValidation;

namespace BeadBE.Application.AuthenticationLogic.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty();
            RuleFor(r => r.LastName).NotEmpty();
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}
