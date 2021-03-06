﻿// <auto-generated />
using System;
using Gore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Gore.Infra.Data.Migrations
{
    [DbContext(typeof(GoreContext))]
    [Migration("20181212172641_AddNeighborhood-Address")]
    partial class AddNeighborhoodAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Gore.Domain.Models.Address", b =>
                {
                    b.Property<int?>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cep")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("City")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Complement")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Neighborhood")
                        .HasColumnName("varchar(100");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("State");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(100)");

                    b.HasKey("AddressId");

                    b.ToTable("address");
                });

            modelBuilder.Entity("Gore.Domain.Models.BloodType", b =>
                {
                    b.Property<int>("BloodTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BloodTypeDescription")
                        .HasColumnType("varchar(50)");

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

            modelBuilder.Entity("Gore.Domain.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int?>("BloodTypeId");

                    b.Property<long>("CPF")
                        .HasColumnType("long");

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

            modelBuilder.Entity("Gore.Domain.Models.Person", b =>
                {
                    b.HasOne("Gore.Domain.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Gore.Domain.Models.BloodType", "BloodType")
                        .WithMany()
                        .HasForeignKey("BloodTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
