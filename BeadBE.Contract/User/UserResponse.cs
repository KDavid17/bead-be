namespace BeadBE.Contract.User
{
    public record UserResponse(
        int Id,
        int RoleId,
        string FirstName,
        string LastName,
        string Email);
}
