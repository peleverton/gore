using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gore.Infra.Data.Mappings
{
    public class BloodTypeMap : IEntityTypeConfiguration<BloodType>
    {
        public void Configure(EntityTypeBuilder<BloodType> builder)
        {
            builder.HasKey(p => p.BloodTypeId);

            builder.Property(p => p.BloodTypeDescription)
                .HasColumnType("varchar(50)");

            builder.ToTable("bloodtype");
        }
    }
}
