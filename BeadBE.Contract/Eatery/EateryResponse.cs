namespace BeadBE.Contract.Eatery
{
    public record EateryResponse(
        int Id,
        int UserId,
        string Name,
        int Height,
        int Width);
}
