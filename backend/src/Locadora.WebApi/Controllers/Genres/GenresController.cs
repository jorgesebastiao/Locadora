using Locadora.Application.Features.Genres.Commands;
using Locadora.Application.Features.Genres.Queries;
using Locadora.Domain.Features.Genres;
using Locadora.WebApi.Controllers.Common;
using Locadora.WebApi.Controllers.Genres.ViewModels;
using Locadora.WebApi.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebApi.Controllers.Genres
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region HttpGet
        /// <summary>
        /// Busca todos os generos no sistema
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Genres
        ///
        /// </remarks>
        /// <returns>Uma lista com os generos</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<GenreViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAllAsync() => await HandleQueryable<Genre, GenreViewModel>(await _mediator.Send(new GenreLoadAllQuery()));

        /// <summary>
        /// Busca um determinado genero pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Genres/ed860648-884f-4f99-a00a-40d01bc6d37d
        ///
        /// </remarks>
        /// <returns>Retorno um Genero</returns>
        [ProducesResponseType(typeof(GenreDetailViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpGet]
        [Route("{genreId}")]
        public async Task<IActionResult> GetByIdAsync(Guid genreId)
        {
            var query = new GenreGetQuery{ GenreId = genreId };

            return HandleQuery<Genre, GenreDetailViewModel>(await _mediator.Send(query));
        }
        #endregion HttpGet

        #region HttpPost
        /// <summary>
        /// Cria um novo Genero no sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Genres
        ///  
        /// </remarks>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] GenreRegisterCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
        #endregion HttpPost

        #region HttpPut
        /// <summary>
        /// Atualiza o Genero.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Genres     
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Core.Results.Unit), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] GenreUpdateCommand command)
        {
            return HandleCommand(await _mediator.Send(command));
        }
        #endregion HttpPut

        #region HttpDelete
        /// <summary>
        /// Deleta um Genero do sistema.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     DELETE /api/Genres/ed860648-884f-4f99-a00a-40d01bc6d37d
        ///
        /// </remarks>
        [ProducesResponseType(typeof(Core.Results.Unit), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpDelete]
        [Route("{genreId}")]
        public async Task<IActionResult> DeleteAsync(Guid genreId)
        {
            return HandleCommand(await _mediator.Send(new GenreRemoveCommand { GenreId = genreId }));
        }
        #endregion HttpDelete
    }
}
