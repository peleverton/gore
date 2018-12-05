using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gore.Infra.Data.Mappings
{
    public class PatientMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.PatientId);

            builder.Property(p => p.Weight)
             .HasColumnType("double");

            builder.Property(p => p.Height)
             .HasColumnType("double");

            builder.Property(p => p.Email)
             .HasColumnType("varchar(100)");

            builder.Property(p => p.Age)
             .HasColumnType("int");

            builder.Property(p => p.Picture)
             .HasColumnType("varchar(100)");

            builder.Property(p => p.Active)
             .HasColumnType("bit(1)");

            builder.Property(p => p.CreatedAt)
             .HasColumnType("datetime");

            builder.Property(p => p.UpdatedAt)
              .HasColumnType("datetime");

            builder.ToTable("patient");
        }
    }
}
