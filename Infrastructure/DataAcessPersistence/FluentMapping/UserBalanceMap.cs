using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class UserBalanceMap : EntityBaseConfiguration<UserBalance>
    {
        public override void ConfigureEntity(EntityTypeBuilder<UserBalance> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Balance).IsRequired();
            builder.HasOne(p => p.User).WithOne().HasForeignKey<UserBalance>(p => p.UserId);

            builder.ToTable("UserBalance", "dbo");
        }
    }
}
