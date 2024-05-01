using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.Context
{
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Register all Entities Fluent API Mapping here
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Scans a given assembly for all types that implement IEntityTypeConfiguration, and registers each one automatically
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<User> User { get; set; }
        public DbSet<Beneficiary> Beneficiary { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<TopUpOption> TopUpOption { get; set; }
        public DbSet<UserTopUpTrasaction> UserTopUpTrasaction { get; set; }
        public DbSet<UserBalance> UserBalance { get; set; }
        public DbSet<BalanceTransaction> BalanceTransaction { get; set; }

    }
}
