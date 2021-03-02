using Locadora.Domain.Features.Movies;
using Locadora.Domain.Features.Rents;
using System;

namespace Locadora.Domain.Features.RentMovies
{
    public class RentMovie
    {
        public Guid RentId { get; set; }
        public Rent Rent { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
