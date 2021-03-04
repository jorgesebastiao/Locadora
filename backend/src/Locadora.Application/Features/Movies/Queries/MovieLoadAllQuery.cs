using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;
using System.Linq;

namespace Locadora.Application.Features.Movies.Queries
{
    public class MovieLoadAllQuery: IRequest<Result<Exception, IQueryable<Movie>>>
    {

    }
}
