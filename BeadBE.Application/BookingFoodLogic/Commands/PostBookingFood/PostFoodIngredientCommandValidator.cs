using FluentValidation;

namespace BeadBE.Application.BookingFoodLogic.Commands.PostBookingFood
{
    public class PostBookingFoodCommandValidator : AbstractValidator<PostBookingFoodCommand>
    {
        public PostBookingFoodCommandValidator()
        {
            RuleFor(bf => bf.BookingId)
                .NotNull()
                .GreaterThan(0);
            RuleFor(bf => bf.FoodId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
