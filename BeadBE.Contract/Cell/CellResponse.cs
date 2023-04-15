namespace BeadBE.Contract.Cell
{
    public record CellResponse(
        int Id,
        int EateryId,
        int? TableId,
        int X,
        int Y);
}
