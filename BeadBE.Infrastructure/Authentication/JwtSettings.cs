namespace BeadBE.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public string Audience { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Secret { get; init; } = string.Empty;
        public int ExpiryMinutes { get; init; }
        public const string SectionName = "JwtSettings";
    }
}
