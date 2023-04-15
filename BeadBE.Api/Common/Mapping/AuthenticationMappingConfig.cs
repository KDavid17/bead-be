using BeadBE.Application.AuthenticationLogic.Common;
using BeadBE.Contracts.Authentication;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest, src => src.User);
        }
    }
}
