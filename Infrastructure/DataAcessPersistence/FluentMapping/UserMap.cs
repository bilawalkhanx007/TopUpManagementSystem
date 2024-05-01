using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcessPersistence.FluentMapping
{
    /// <summary>
    /// FluentAPI Mapping
    /// </summary>
    public class UserMap : EntityBaseConfiguration<User>
    {
        public override void ConfigureEntity(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.FirstNameEnglish).IsRequired();
            builder.Property(p => p.FirstNameArabic).IsRequired();
            builder.Property(p => p.MobileNumber).IsRequired();

            builder.ToTable("User", "dbo");
        }
    }
}
