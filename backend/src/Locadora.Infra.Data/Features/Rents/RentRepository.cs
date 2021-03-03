using Locadora.Domain.Features.Rents;
using Locadora.Infra.Data.Contexts;

namespace Locadora.Infra.Data.Features.Rents
{
    public class RentRepository: IRentRepository
    {
        private readonly LocadoraDbContext _context;

        public RentRepository(LocadoraDbContext context)
        {
            _context = context;
        }
    }
}
