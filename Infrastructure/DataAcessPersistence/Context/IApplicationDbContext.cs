using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Beneficiary> Beneficiary { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TopUpOption> TopUpOption { get; set; }
        public DbSet<UserTopUpTrasaction> UserTopUpTrasaction { get; set; }
        public DbSet<UserBalance> UserBalance { get; set; }
        public DbSet<BalanceTransaction> BalanceTransaction { get; set; }
    }
}
