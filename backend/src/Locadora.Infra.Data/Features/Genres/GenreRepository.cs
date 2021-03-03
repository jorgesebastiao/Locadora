using Locadora.Domain.Features.Genres;
using Locadora.Infra.Data.Contexts;

namespace Locadora.Infra.Data.Features.Genres
{
    public class GenreRepository: IGenreRepository
    {
        private readonly LocadoraDbContext _context;

        public GenreRepository(LocadoraDbContext context)
        {
            _context = context;
        }
    }
}
