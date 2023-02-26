using System.Net;

namespace BeadBE.Application.Common.Responses
{
    public class ServiceError : IBaseResponse
    {
        public HttpStatusCode StatusCode { get; }
        public string Title { get; } = string.Empty;
        public List<ValidationError> Errors { get; } = new();

        public bool IsError => true;

        public ServiceError(HttpStatusCode statusCode, string description)
        {
            StatusCode = statusCode;
            Title = description;
        }

        public ServiceError(HttpStatusCode statusCode, string description, List<ValidationError> errors)
        {
            StatusCode = statusCode;
            Title = description;
            Errors = errors;
        }
    }
}