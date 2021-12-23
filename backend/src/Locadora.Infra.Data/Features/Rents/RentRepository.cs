using Locadora.Core.Exceptions;
using Locadora.Core.Results;
using Locadora.Domain.Features.Rents;
using Locadora.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Features.Rents
{
    public class RentRepository: IRentRepository
    {
        private readonly LocadoraDbContext _context;

        public RentRepository(LocadoraDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Cadastra um novo aluguel.
        /// </summary>
        /// <param name="movie">aluguel para ser cadastrado</param>
        /// <returns>O aluguel que foi cadastrado</returns>
        public async Task<Result<Exception, Rent>> AddAsync(Rent rent)
        {
            var newRent = _context.Rents.Add(rent).Entity;

            var saveChangesCallback = await Result.Run(async () => await _context.SaveChangesAsync());
            if (saveChangesCallback.IsFailure)
                return saveChangesCallback.Failure;

            return newRent;
        }

        /// <summary>
        /// Retorna todos os alugueis cadastrados.
        /// </summary>
        /// <returns>IQueryable de alugueis</returns>
        public Result<Exception, IQueryable<Rent>> GetAll()
        {
            return Result.Run(() => _context.Rents.AsQueryable());
        }

        /// <summary>
        /// Busca um aluguel pelo Id.
        /// </summary>
        /// <param name="rent">Id do alguel</param>
        /// <returns>Aluguel cadastrado</returns>
        public async Task<Result<Exception, Rent>> GetById(Guid rentId)
        {
            var rentCallback = await Result.Run(() => _context.Rents.FirstOrDefaultAsync(x => x.Id == rentId));

            if (rentCallback.IsFailure)
                return rentCallback.Failure;

            if (rentCallback.Success == null)
                return new NotFoundException();

            return rentCallback;
        }
    }
}
