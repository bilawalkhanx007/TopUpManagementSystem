using DataAcessPersistence.Context;
using DataAcessPersistence.Repositories;
using Domain.Abstructions;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;

namespace DataAcessPersistence.UnitOfWork
{
    public class BalanceManagementAppUnitOfWork : IBalanceManagementAppUnitOfWork, IAsyncDisposable
    {
        private readonly ApplicationDbContext _context;

        public IUserBalanceRepository UserBalanceRepository { get; private set; }
        public IBalanceTransactionRepository BalanceTransactionRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public IUserTopUpTrasactionRepository UserTopUpTrasactionRepository { get; private set; }
        public IBeneficiaryBalanceRepository BeneficiaryBalanceRepository { get; private set; }


        /// <summary>
        /// Conturctor
        /// </summary>
        /// <param name="context"></param>
        public BalanceManagementAppUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserBalanceRepository = new UserBalanceRepository(_context);
            BalanceTransactionRepository = new BalanceTransactionRepository(_context);
            UserRepository = new UserRepository(_context);
            UserTopUpTrasactionRepository = new UserTopUpTrasactionRepository(_context);
            BeneficiaryBalanceRepository = new BeneficiaryBalanceRepository(_context);
        }

        /// <summary>
        /// To Perform SaveChanges
        /// </summary>
        /// <returns></returns>
        public async Task<int> ApplySaveChanges(CancellationToken cancellationToken)
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


        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();
            return transaction.GetDbTransaction();
        }
    }
}
