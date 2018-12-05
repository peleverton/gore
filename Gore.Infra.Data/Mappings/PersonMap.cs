using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Gore.Infra.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {

            builder.HasKey(p => p.PersonId);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasColumnType("long");

            builder.Property(p => p.Email)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(p => p.DateOfBirth)
               .HasColumnType("DateTime");

            builder.Property(p => p.Phone)
               .HasColumnType("int");

            builder.Property(p => p.IsActive)
                .HasColumnType("bool");

            builder.HasOne(p => p.Address);

           // builder.HasQueryFilter(p => EF.Property<int>(p, Convert.ToString(p.AddressId) ==  Convert.ToString(p.Address.AddressId)));
            //.HasQueryFilter(b => EF.Property<string>(b, "TenantId") == _tenantId);

            builder.HasOne(p => p.BloodType);

            builder.ToTable("person");
        }
    }
}
