using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using MediatR;
using System;
using System.Linq;

namespace Locadora.Application.Features.Genres.Queries
{
    public class GenreLoadAllQuery: IRequest<Result<Exception, IQueryable<Genre>>>
    {

    }
}
