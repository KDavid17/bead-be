using FluentValidation;

namespace BeadBE.Application.TableLogic.Commands.PostTable
{
    public class PostTableCommandValidator : AbstractValidator<PostTableCommand>
    {
        public PostTableCommandValidator()
        {
            RuleFor(t => t.Seats)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
