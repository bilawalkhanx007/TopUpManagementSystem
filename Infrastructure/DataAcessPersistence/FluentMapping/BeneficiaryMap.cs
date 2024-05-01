using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class BeneficiaryMap : EntityBaseConfiguration<Beneficiary>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Beneficiary> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.NickName).IsRequired();
            builder.Property(p => p.MobileNumber).IsRequired();

            builder.ToTable("Beneficiary", "dbo");
        }
    }
}
