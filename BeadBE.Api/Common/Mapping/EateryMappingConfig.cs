using BeadBE.Application.EateryLogic.Commands.PutEatery;
using BeadBE.Application.EateryLogic.Common;
using BeadBE.Contract.Eatery;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class EateryMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, EateryRequest Request), PutEateryCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<EateryResult, EateryResponse>()
                .Map(dest => dest, src => src.Eatery);

            config.NewConfig<EateriesResult, EateriesResponse>()
                .Map(dest => dest, src => src.Eaterys);
        }
    }
}
