using BeadBE.Application.IngredientLogic.Commands.PutIngredient;
using BeadBE.Application.IngredientLogic.Common;
using BeadBE.Contract.Ingredient;
using Mapster;

namespace BeadBE.Api.Common.Mapping
{
    public class IngredientMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(int Id, IngredientRequest Request), PutIngredientCommand>()
                .Map(dest => dest, src => src.Request)
                .Map(dest => dest.Id, src => src.Id);

            config.NewConfig<IngredientResult, IngredientResponse>()
                .Map(dest => dest, src => src.Ingredient);

            config.NewConfig<IngredientsResult, IngredientsResponse>()
                .Map(dest => dest, src => src.Ingredients);
        }
    }
}
