using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class UserBalanceRepository : Repository<UserBalance>, IUserBalanceRepository
    {
        private readonly ApplicationDbContext context;
        public UserBalanceRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        /// <summary>
        /// This Method is use to Get All User Balance
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<UserBalance> GetUserBalance(long userId, CancellationToken cancellationToken = default)
        {
            var userBalance = await context.UserBalance.Include(x => x.User)
                                            .FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
            if(userBalance != null)
                return userBalance;
            else
              return new UserBalance();
        }
    }
}
