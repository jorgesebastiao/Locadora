using Locadora.Core.Exceptions;
using Locadora.Core.Results;
using Locadora.Domain.Features.Genres;
using Locadora.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Genres
{
    public class GenreRepository: IGenreRepository
    {
        private readonly LocadoraDbContext _context;

        public GenreRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastra um novo Genero.
        /// </summary>
        /// <param name="genre">genero para ser cadastrado</param>
        /// <returns>O genero que foi cadastrado</returns>
        public async Task<Result<Exception, Genre>> AddAsync(Genre genre)
        {
            var newGenre = _context.Genres.Add(genre).Entity;

            var saveChangesCallback = await Result.Run(async () => await _context.SaveChangesAsync());
            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return newGenre;
        }

        /// <summary>
        /// Retornar todos os generos cadastrados.
        /// </summary>
        /// <returns>IQueryable de generos</returns>
        public Result<Exception, IQueryable<Genre>> GetAll()
        {
            return Result.Run(() => _context.Genres.Where(x => !x.IsRemoved).AsQueryable());
        }

        /// <summary>
        /// Busca um genero pelo Id.
        /// </summary>
        /// <param name="genre">Id do genero</param>
        /// <returns>Genero cadastrado</returns>
        public async Task<Result<Exception, Genre>> GetById(Guid genreId)
        {
            var genreCallback = await Result.Run(() => _context.Genres.FirstOrDefaultAsync(x => x.Id == genreId && !x.IsRemoved));

            if (genreCallback.IsFailure)
                return genreCallback.Failure;

            if (genreCallback.Success == null)
                return new NotFoundException();

            return genreCallback;
        }

        /// <summary>
        /// Atualiza os dados do Genero.
        /// </summary>
        /// <param name="genre">genero para ser atualizado</param>
        /// <returns>O genero que foi atualizado</returns>
        public async Task<Result<Exception, Genre>> UpdateAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            var saveChangesCallback = await Result.Run(() => _context.SaveChangesAsync());

            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return genre;
        }
    }
}
