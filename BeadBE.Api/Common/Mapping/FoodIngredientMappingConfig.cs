using BeadBE.Application.FoodIngredientLogic.Commands.PutFoodIngredient;
using BeadBE.Contract.FoodIngredient;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class FoodIngredientMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, FoodIngredientRequest Request), PutFoodIngredientCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);
        }
    }
}
