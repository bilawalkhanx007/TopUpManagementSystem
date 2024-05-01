using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class BalanceTransactionRepository : Repository<BalanceTransaction>, IBalanceTransactionRepository
    {
        private readonly ApplicationDbContext context;
        public BalanceTransactionRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
