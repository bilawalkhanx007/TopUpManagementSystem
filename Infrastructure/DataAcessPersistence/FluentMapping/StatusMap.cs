using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class StatusMap : EntityBaseConfiguration<Status>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Status> builder)
        {
            builder.Property(p => p.Name).IsRequired();

            builder.ToTable("Status", "dbo");
        }
    }
}
