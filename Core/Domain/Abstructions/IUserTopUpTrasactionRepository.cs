using Domain.Entities;

namespace Domain.Abstructions
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IUserTopUpTrasactionRepository : IRepository<UserTopUpTrasaction>
    {
        /// <summary>
        /// This Method is use to Get All User Monthly TopUp Trasaction
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="startDateOfMonth"></param>
        /// <param name="endDateOfMonth"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<UserTopUpTrasaction>> GetUserMonthlyTopUpTrasaction(long userId,
                                                                            DateTime startDateOfMonth,
                                                                            DateTime endDateOfMonth,
                                                                            CancellationToken cancellationToken = default);
    }
}
