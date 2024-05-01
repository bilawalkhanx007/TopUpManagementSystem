using Domain.Entities;

namespace Domain.Abstructions
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IUserBalanceRepository : IRepository<UserBalance>
    {
        /// <summary>
        /// This Method is use to Get All User Balance
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<UserBalance> GetUserBalance(long userId, CancellationToken cancellationToken = default);
    }
}
