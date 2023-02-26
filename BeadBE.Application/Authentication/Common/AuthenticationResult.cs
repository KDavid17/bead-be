using BeadBE.Application.Common.Responses;
using BeadBE.Domain.Entities;

namespace BeadBE.Application.Authentication.Common
{
    public record AuthenticationResult(UserEntity User, string Token) : IBaseResponse
    {
        public bool IsError => false;
    }
}