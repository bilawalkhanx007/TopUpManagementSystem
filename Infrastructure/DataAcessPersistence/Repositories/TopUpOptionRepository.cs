using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class TopUpOptionRepository : Repository<TopUpOption>, ITopUpOptionRepository
    {
        private readonly ApplicationDbContext context;
        public TopUpOptionRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }
    }
}
