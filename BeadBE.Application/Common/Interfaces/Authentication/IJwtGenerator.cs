namespace BeadBE.Application.Common.Interfaces.Authentication
{
    public interface IJwtGenerator
    {
        string GenerateToken(string email);
    }
}
