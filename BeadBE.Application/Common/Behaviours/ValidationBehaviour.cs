using BeadBE.Application.Common.Responses;
using FluentValidation;
using MediatR;

namespace BeadBE.Application.Common.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IBaseResponse
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviour(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            List<ValidationError> errors = validationResult.Errors
                .ConvertAll(validationFailure => new ValidationError(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            ServiceError error = new(System.Net.HttpStatusCode.BadRequest, "One or more validation errors occured", errors);

            return (TResponse)(IBaseResponse)error;
        }
    }

    /*public class ValidationBehaviour : IPipelineBehavior<RegisterCommand, ErrorOr<AuthenticationResult>>
    {
        private readonly IValidator<RegisterCommand> _validator;

        public ValidationBehaviour(IValidator<RegisterCommand> validator)
        {
            _validator = validator;
        }

        public async Task<ErrorOr<AuthenticationResult>> Handle(
            RegisterCommand request,
            RequestHandlerDelegate<ErrorOr<AuthenticationResult>> next,
            CancellationToken cancellationToken)
        {
            ValidationResult validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }

            List<Error> errors = validationResult.Errors
                .ConvertAll(validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage));

            return errors;
        }
    }*/
}
