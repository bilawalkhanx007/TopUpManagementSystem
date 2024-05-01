using DataAcessPersistence.Context;
using Domain.Abstructions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.Repositories
{
    /// <summary>
    /// Repository
    /// </summary>
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext context;
        public UserRepository(ApplicationDbContext _context) : base(_context)
        {
            context = _context;
        }

        /// <summary>
        /// This Method is use to Add User
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task AddUser(User user, CancellationToken cancellationToken = default)
        {
            await context.User.AddAsync(user);
        }


        /// <summary>
        /// This Method is use to Get User Details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<User> GetUser(long userId, CancellationToken cancellationToken = default)
        {
            var user = new User();
            user = await context.User.AsNoTracking()
                                     .FirstOrDefaultAsync(x => x.Id == userId && x.IsActive == true, cancellationToken);
            return user;
        }
    }
}
