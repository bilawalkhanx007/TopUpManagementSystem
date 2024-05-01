using DataAcessPersistence.Context;
using DataAcessPersistence.Repositories;
using Domain.Abstructions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.UnitOfWork
{
    /// <summary>
    /// All Repositories register into UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IAsyncDisposable
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository UserRepository { get; private set; }
        public IBeneficiaryRepository BeneficiaryRepository { get; private set; }
        public ITopUpOptionRepository TopUpOptionRepository { get; private set; }
        public IUserTopUpTrasactionRepository UserTopUpTrasactionRepository { get; private set; }


        /// <summary>
        /// Conturctor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserRepository = new UserRepository(_context);
            BeneficiaryRepository = new BeneficiaryRepository(_context);
            TopUpOptionRepository = new TopUpOptionRepository(_context);
            UserTopUpTrasactionRepository = new UserTopUpTrasactionRepository(_context);
        }


        /// <summary>
        /// BeginTransaction
        /// </summary>
        /// <returns></returns>
        public IDbTransaction BeginTransaction()
        { 
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }



        /// <summary>
        /// To Perform SaveChanges
        /// </summary>
        /// <returns></returns>
        public async Task<int> ApplySaveChanges(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// No matter an exception has been raised or not, this method always will dispose the DbContext 
        /// </summary>
        /// <returns></returns>
        public ValueTask DisposeAsync()
        {
            return _context.DisposeAsync();
        }
    }
}
