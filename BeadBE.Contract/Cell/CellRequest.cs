namespace BeadBE.Contract.Cell
{
    public record CellRequest(
        int EateryId,
        int? TableId,
        int X,
        int Y);
}
