using FluentValidation;

namespace BeadBE.Application.BookingFoodLogic.Commands.PutBookingFood
{
    public class PutBookingFoodCommandValidator : AbstractValidator<PutBookingFoodCommand>
    {
        public PutBookingFoodCommandValidator()
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
