using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstructions
{
    /// <summary>
    /// Repository Interface
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// This Method is use to Add User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddUser(User user, CancellationToken cancellationToken = default);


        /// <summary>
        /// This Method is use to Get User Details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> GetUser(long userId, CancellationToken cancellationToken = default);
    }
}
