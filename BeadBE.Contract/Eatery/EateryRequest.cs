namespace BeadBE.Contract.Eatery
{
    public record EateryRequest(
        int UserId,
        string Name,
        int Height,
        int Width);
}
