using BeadBE.Application.Common.Interfaces.Services;

namespace BeadBE.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
