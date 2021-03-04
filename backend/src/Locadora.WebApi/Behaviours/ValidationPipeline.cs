using FluentValidation;
using Locadora.Application.Behaviours;
using Locadora.Core.Results;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Locadora.WebApi.Behaviours
{
    public class ValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, Result<Exception, TResponse>>
        where TRequest : IRequestWithResult<TResponse>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPipeline(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<Result<Exception, TResponse>> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Result<Exception, TResponse>> next)
        {
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(error => error != null)
                .ToList();

            if (failures.Any())
            {
                return new ValidationException(failures);
            }

            return await next();
        }
    }
}
