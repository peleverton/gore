using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gore.Infra.Data.Mappings
{
    public class MedicalAppointmentMap : IEntityTypeConfiguration<MedicalAppointment>
    {
        public void Configure(EntityTypeBuilder<MedicalAppointment> builder)
        {
            builder.HasKey(p => p.MedicalAppointmentId);

            builder.ToTable("medicalappointment");
        }
    }
}
