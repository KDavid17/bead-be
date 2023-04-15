using FluentValidation;

namespace BeadBE.Application.UserLogic.Commands.PutUser
{
    public class PutUserCommandValidator : AbstractValidator<PutUserCommand>
    {
        public PutUserCommandValidator()
        {
            RuleFor(u => u.RoleId).NotNull();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(u => u.Password)
                .NotEmpty();
        }
    }
}
