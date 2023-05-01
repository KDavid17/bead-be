using BeadBE.Application.UserLogic.Commands.PutUser;
using BeadBE.Application.UserLogic.Common;
using BeadBE.Contract.User;
using BeadBE.Domain.Entities;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserResult, UserResponse>()
                .Map(dest => dest, src => src.User);

            config.NewConfig<UserResult, UserProfileResponse>()
                .Map(dest => dest, src => src.User);

            config.NewConfig<UsersResult, UsersResponse>()
                .Map(dest => dest, src => src.Users);

            config.ForType<PutUserCommand, User>()
                .Ignore(dest => dest.Password);
        }
    }
}
