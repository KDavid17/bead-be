using BeadBE.Application.FoodLogic.Commands.PutFood;
using BeadBE.Application.FoodLogic.Common;
using BeadBE.Contract.Food;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class FoodMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int, FoodRequest), PutFoodCommand>()
                .Map(dest => dest, src => src.Item2)
                .Map(dest => dest.Id, src => src.Item1);

            config.NewConfig<FoodResult, FoodResponse>()
                .Map(dest => dest, src => src.Food);

            config.NewConfig<FoodsResult, FoodsResponse>()
                .Map(dest => dest, src => src.Foods);

            config.NewConfig<FoodDetailsResult, FoodDetailsResponse>()
                .Map(dest => dest, src => src.FoodDetails);

            config.NewConfig<FoodsDetailsResult, FoodsDetailsResponse>()
                .Map(dest => dest, src => src.FoodsDetails);
        }
    }
}
