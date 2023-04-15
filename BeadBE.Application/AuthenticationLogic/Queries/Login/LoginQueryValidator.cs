using FluentValidation;

namespace BeadBE.Application.AuthenticationLogic.Queries.Login
{
    public class LoginQueryValidator : AbstractValidator<LoginQuery>
    {
        public LoginQueryValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(r => r.Password).NotEmpty();
        }
    }
}
