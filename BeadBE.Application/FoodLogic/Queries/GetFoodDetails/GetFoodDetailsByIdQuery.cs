using BeadBE.Application.FoodLogic.Common;
using MediatR;

namespace BeadBE.Application.FoodLogic.Queries.GetFoodDetails;

public record GetFoodDetailsByIdQuery(int Id) : IRequest<FoodDetailsResult>;
