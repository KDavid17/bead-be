namespace BeadBE.Application.Common.Interfaces.Services
{
    public interface IHashService
    {
        public void CreateHash(string password, out byte[] hash, out byte[] salt);
        public bool VerifyCredentials(string password, byte[] hash, byte[] salt);
    }
}
