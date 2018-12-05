using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gore.Infra.Data.Mappings
{
    public class DoctorMap : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.DoctorId);

            builder.Property(d => d.CRM)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.HasOne(d => d.Person);
                        
            builder.ToTable("doctor");
        }
    }
}
