using System.Net;

namespace BeadBE.Application.Common.Interfaces.Errors
{
    public interface IServiceException
    {
        public HttpStatusCode StatusCode { get; }
        public string Message { get; }
    }
}
