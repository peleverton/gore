using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gore.Infra.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(p => p.AddressId);

            builder.Property(p => p.Street)
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Number)
                .HasColumnType("int");

            builder.Property(p => p.Cep)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Complement)
                .IsRequired(false)
               .HasColumnType("varchar(200)");

            builder.Property(p => p.City)
               .HasColumnType("varchar(150)");

            builder.Property(p => p.Street)
               .HasColumnType("varchar(100)");

            builder.Property(p => p.Neighborhood)
                .HasColumnType("varchar(100)");

            builder.ToTable("address");
        }
    }
}
