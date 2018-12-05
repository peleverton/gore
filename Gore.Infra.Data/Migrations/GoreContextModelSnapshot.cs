﻿// <auto-generated />
using Gore.Domain.Models;
using Gore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Gore.Infra.Data.Migrations
{
    [DbContext(typeof(GoreContext))]
    partial class GoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026");

            modelBuilder.Entity("Gore.Domain.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cep")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("State");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("complement")
                        .HasColumnType("varchar(200)");

                    b.HasKey("AddressId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("Gore.Domain.Models.BloodType", b =>
                {
                    b.Property<Guid>("BloodTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BloodTypeDescription")
                        .HasColumnType("varchar(50)");

                    b.Property<Guid>("Id");

                    b.HasKey("BloodTypeId");

                    b.ToTable("bloodtype");
                });

            modelBuilder.Entity("Gore.Domain.Models.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CRM")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("PersonId");

                    b.HasKey("DoctorId");

                    b.HasIndex("PersonId");

                    b.ToTable("doctor");
                });

            modelBuilder.Entity("Gore.Domain.Models.MedicalAppointment", b =>
                {
                    b.Property<int>("MedicalAppointmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DoctorId");

                    b.Property<int?>("PatientId");

                    b.Property<DateTimeOffset?>("SchedulingDate");

                    b.HasKey("MedicalAppointmentId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("medicalappointment");
                });

            modelBuilder.Entity("Gore.Domain.Models.MedicalProcedure", b =>
                {
                    b.Property<int>("MedicalProcedureId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset?>("DateOfProcedure");

                    b.Property<int?>("DoctorId");

                    b.Property<string>("Materials")
                        .IsRequired()
                        .HasColumnType("varchar(400)");

                    b.Property<string>("MedicalProcedureDescription")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("PatientId");

                    b.HasKey("MedicalProcedureId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("medicalprocedure");
                });

            modelBuilder.Entity("Gore.Domain.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active")
                        .HasColumnType("bit(1)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int?>("DoctorId");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Height")
                        .HasColumnType("double");

                    b.Property<int?>("PersonId");

                    b.Property<string>("Picture")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.Property<double>("Weight")
                        .HasColumnType("double");

                    b.HasKey("PatientId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PersonId");

                    b.ToTable("patient");
                });

            modelBuilder.Entity("Gore.Domain.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AddressId");

                    b.Property<Guid?>("BloodTypeId");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("DateTime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Gender");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bool");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("PersonId");

                    b.HasIndex("AddressId");

                    b.HasIndex("BloodTypeId");

                    b.ToTable("person");
                });

            modelBuilder.Entity("Gore.Domain.Models.Doctor", b =>
                {
                    b.HasOne("Gore.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Gore.Domain.Models.MedicalAppointment", b =>
                {
                    b.HasOne("Gore.Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Gore.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Gore.Domain.Models.MedicalProcedure", b =>
                {
                    b.HasOne("Gore.Domain.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId");

                    b.HasOne("Gore.Domain.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("Gore.Domain.Models.Patient", b =>
                {
                    b.HasOne("Gore.Domain.Models.Doctor")
                        .WithMany("Patients")
                        .HasForeignKey("DoctorId");

                    b.HasOne("Gore.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("Gore.Domain.Models.Person", b =>
                {
                    b.HasOne("Gore.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("Gore.Domain.Models.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
