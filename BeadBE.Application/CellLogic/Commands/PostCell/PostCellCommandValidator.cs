using FluentValidation;

namespace BeadBE.Application.CellLogic.Commands.PostCell
{
    public class PostCellCommandValidator : AbstractValidator<PostCellCommand>
    {
        public PostCellCommandValidator()
        {
            RuleFor(i => i.Name).NotEmpty();
            RuleFor(i => i.IsAllergen).NotNull();
        }
    }
}
