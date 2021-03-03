using Locadora.Domain.Features.Movies;
using Locadora.Infra.Data.Contexts;

namespace Locadora.Infra.Data.Features.Movies
{
    public class MovieRepository: IMovieRepository
    {
        private readonly LocadoraDbContext _context;

        public MovieRepository(LocadoraDbContext context)
        {
            _context = context;
        }
    }
}
