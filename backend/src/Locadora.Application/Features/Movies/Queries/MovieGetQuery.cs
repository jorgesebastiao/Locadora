using FluentValidation;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using MediatR;
using System;

namespace Locadora.Application.Features.Movies.Queries
{
    public  class MovieGetQuery : IRequest<Result<Exception, Movie>>
    {
        public Guid MovieId { get; set; }
    }

    public class MovieGetQueryValidator : AbstractValidator<MovieGetQuery>
    {
        public MovieGetQueryValidator()
        {
            RuleFor(x => x.MovieId)
                .NotNull()
                .NotEmpty();
        }
    }
}
