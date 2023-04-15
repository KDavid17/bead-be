namespace BeadBE.Contract.User
{
    public record UserRequest(
        int RoleId,
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
