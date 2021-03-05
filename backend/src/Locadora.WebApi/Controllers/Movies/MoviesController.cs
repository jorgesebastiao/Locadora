using Locadora.Application.Features.Movies.Commands;
using Locadora.Application.Features.Movies.Queries;
using Locadora.Domain.Features.Movies;
using Locadora.WebApi.Controllers.Common;
using Locadora.WebApi.Controllers.Movies.ViewModels;
using Locadora.WebApi.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebApi.Controllers.Movies
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController: ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region HttpGet
        /// <summary>
        /// Busca todos os filmes
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Movies
        ///
        /// </remarks>
        /// <returns>Uma lista com os filmes</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MovieViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAllAsync() => await HandleQueryable<Movie, MovieViewModel>(await _mediator.Send(new MovieLoadAllQuery()));

        /// <summary>
        /// Busca um determinado filme pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Movies/ed860648-884f-4f99-a00a-40d01bc6d37d
        ///
        /// </remarks>
        /// <returns>Retorna um filme</returns>
        [ProducesResponseType(typeof(MovieDetailViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpGet]
        [Route("{movieId}")]
        public async Task<IActionResult> GetByIdAsync(Guid movieId)
        {
            var query = new MovieGetQuery { MovieId = movieId };

            return HandleQuery<Movie, MovieDetailViewModel>(await _mediator.Send(query));
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Registra um novo Filme.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Movies
        ///  
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] MovieRegisterCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Atualiza o Filme.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Movies     
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Core.Results.Unit), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] MovieUpdateCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Remove um Filme.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/Movies/ed860648-884f-4f99-a00a-40d01bc6d37d
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Core.Results.Unit), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpDelete]
        [Route("{movieId}")]
        public async Task<IActionResult> DeleteAsync(Guid movieId)
        {
            return HandleCommand(await _mediator.Send(new MovieRemoveCommand { MovieId = movieId }));
        }

        /// <summary>
        /// Remove multiplos filmes.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/Movies
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Core.Results.Unit), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpDelete]
        public async Task<IActionResult> DeleteMultiplesAsync(MovieRemoveMultipleCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
        #endregion HttpDelete
    }
}
