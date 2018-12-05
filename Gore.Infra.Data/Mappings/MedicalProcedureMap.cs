using Gore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gore.Infra.Data.Mappings
{
    public class MedicalProcedureMap : IEntityTypeConfiguration<MedicalProcedure>
    {
        public void Configure(EntityTypeBuilder<MedicalProcedure> builder)
        {
            builder.HasKey(p => p.MedicalProcedureId);

            builder.Property(p => p.MedicalProcedureDescription)
              .IsRequired()
              .HasColumnType("varchar(250)");

            builder.Property(p => p.Materials)
              .IsRequired()
              .HasColumnType("varchar(400)");

            builder.ToTable("medicalprocedure");
        }
    }
}
