using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class BeneficiaryBalanceRepository : Repository<BeneficiaryBalance>, IBeneficiaryBalanceRepository
    {
        private readonly ApplicationDbContext context;
        public BeneficiaryBalanceRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
