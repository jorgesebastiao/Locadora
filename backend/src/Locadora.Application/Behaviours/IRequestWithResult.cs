using Locadora.Core.Results;
using MediatR;
using System;

namespace Locadora.Application.Behaviours
{
    public interface IRequestWithResult<TResponse> : IRequest<Result<Exception, TResponse>>
    {
    }
}
