using DataAcessPersistence.Context;
using DataAcessPersistence.UnitOfWork;
using Domain.Abstructions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class UserTopUpTrasactionRepository : Repository<UserTopUpTrasaction>, IUserTopUpTrasactionRepository
    {
        private readonly ApplicationDbContext context;
        public UserTopUpTrasactionRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        /// <summary>
        /// This Method is use to Get All User Monthly TopUp Trasaction
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDateOfMonth"></param>
        /// <param name="endDateOfMonth"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<UserTopUpTrasaction>> GetUserMonthlyTopUpTrasaction(long userId, 
                                                                            DateTime startDateOfMonth,
                                                                            DateTime endDateOfMonth,
                                                                            CancellationToken cancellationToken = default)
        {
            var userMonthlyTopUpTrasactionList = await context.UserTopUpTrasaction
                                                       .Where(x => x.UserID == userId
                                                        && x.CreatedAt >= startDateOfMonth && x.CreatedAt <= endDateOfMonth)
                                                       .ToListAsync(cancellationToken);

            return userMonthlyTopUpTrasactionList;
        }
    }
}
