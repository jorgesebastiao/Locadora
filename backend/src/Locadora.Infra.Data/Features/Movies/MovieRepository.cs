using Locadora.Core.Exceptions;
using Locadora.Core.Results;
using Locadora.Domain.Features.Movies;
using Locadora.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Movies
{
    public class MovieRepository: IMovieRepository
    {
        private readonly LocadoraDbContext _context;

        public MovieRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastra um novo Filme.
        /// </summary>
        /// <param name="movie">filme para ser cadastrado</param>
        /// <returns>O filme que foi cadastrado</returns>
        public async Task<Result<Exception, Movie>> AddAsync(Movie movie)
        {
            var newMovie = _context.Movies.Add(movie).Entity;

            var saveChangesCallback = await Result.Run(async () => await _context.SaveChangesAsync());
            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return newMovie;
        }

        /// <summary>
        /// Retornar todos os filmes cadastrados.
        /// </summary>
        /// <returns>IQueryable de filmes</returns>
        public Result<Exception, IQueryable<Movie>> GetAll()
        {
            return Result.Run(() => _context.Movies.Where(x => !x.IsRemoved)
                                                   .Include(x => x.Genre)
                                                   .AsQueryable());
        }

        /// <summary>
        /// Busca um filme pelo Id.
        /// </summary>
        /// <param name="movie">Id do filme</param>
        /// <returns>filme cadastrado</returns>
        public async Task<Result<Exception, Movie>> GetById(Guid movieId)
        {
            var movieCallback = await Result.Run(() => _context.Movies.FirstOrDefaultAsync(x => x.Id == movieId && !x.IsRemoved));

            if (movieCallback.IsFailure)
                return movieCallback.Failure;

            if (movieCallback.Success == null)
                return new NotFoundException();

            return movieCallback;
        }

        /// <summary>
        /// Atualiza os dados do Filme.
        /// </summary>
        /// <param name="movie">filme para ser atualizado</param>
        /// <returns>O filme que foi atualizado</returns>
        public async Task<Result<Exception, Movie>> UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            var saveChangesCallback = await Result.Run(() => _context.SaveChangesAsync());

            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return movie;
        }
    }
}
