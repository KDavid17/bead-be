namespace BeadBE.Contract.Food
{
    public record FoodResponse(
        int Id,
        int EateryId,
        string Name,
        decimal Price);
}
