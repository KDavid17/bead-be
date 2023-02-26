namespace BeadBE.Infrastructure.Database
{
    public class DatabaseOptions
    {
        public int MaxRetryCount { get; set; }
        public int CommandTimeout { get; set; }
        public bool EnableDatailedErrors { get; set; }
        public bool EnableSensitiveDataLogging { get; set; }
        public const string SectionName = "DatabaseSettings";
    }
}
