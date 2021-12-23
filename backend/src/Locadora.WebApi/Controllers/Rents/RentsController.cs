using Locadora.Application.Features.Rents.Queries;
using Locadora.Domain.Features.Rents;
using Locadora.WebApi.Controllers.Common;
using Locadora.WebApi.Controllers.Rents.ViewModels;
using Locadora.WebApi.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebApi.Controllers.Rents
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController: ApiControllerBase
    {
        private readonly IMediator _mediator;

        public RentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region HttpGet
        /// <summary>
        /// Busca todos os alugeuis
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Rents
        ///
        /// </remarks>
        /// <returns>Uma lista com os alugueis</returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<RentViewModel>))]
        [ProducesResponseType(400, Type = typeof(ExceptionPayload))]
        [ProducesResponseType(500, Type = typeof(ExceptionPayload))]
        public async Task<IActionResult> GetAllAsync() => await HandleQueryable<Rent, RentViewModel>(await _mediator.Send(new RentLoadAllQuery()));

        /// <summary>
        /// Busca um determinado aluguel pelo seu identificador.
        /// </summary>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     GET /api/Rents/ed860648-884f-4f99-a00a-40d01bc6d37d
        ///
        /// </remarks>
        /// <returns>Retorna um aluguel</returns>
        [ProducesResponseType(typeof(RentDetailViewModel), 200)]
        [ProducesResponseType(typeof(ExceptionPayload), 400)]
        [ProducesResponseType(typeof(ExceptionPayload), 404)]
        [ProducesResponseType(typeof(ExceptionPayload), 500)]
        [HttpGet]
        [Route("{rentId}")]
        public async Task<IActionResult> GetByIdAsync(Guid rentId)
        {
            var query = new RentGetQuery { RentId = rentId };

            return HandleQuery<Rent, RentDetailViewModel>(await _mediator.Send(query));
        }
        #endregion HttpGet
    }
}
