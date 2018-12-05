using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gore.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    AddressId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Street = table.Column<string>(type: "varchar(100)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<int>(type: "int", nullable: false),
                    complement = table.Column<string>(type: "varchar(200)", nullable: true),
                    City = table.Column<string>(type: "varchar(150)", nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.AddressId);
                });

            migrationBuilder.CreateTable(
                name: "bloodtype",
                columns: table => new
                {
                    BloodTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BloodTypeDescription = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bloodtype", x => x.BloodTypeId);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(150)", nullable: false),
                    CPF = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DateTime", nullable: false),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    AddressId = table.Column<int>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(type: "bool", nullable: false),
                    BloodTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_person_address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_person_bloodtype_BloodTypeId",
                        column: x => x.BloodTypeId,
                        principalTable: "bloodtype",
                        principalColumn: "BloodTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "doctor",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CRM = table.Column<string>(type: "varchar(50)", nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctor", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_doctor_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Weight = table.Column<double>(type: "double", nullable: false),
                    Height = table.Column<double>(type: "double", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<string>(type: "varchar(100)", nullable: true),
                    Active = table.Column<bool>(type: "bit(1)", nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    DoctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patient", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_patient_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_patient_person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medicalappointment",
                columns: table => new
                {
                    MedicalAppointmentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchedulingDate = table.Column<DateTimeOffset>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalappointment", x => x.MedicalAppointmentId);
                    table.ForeignKey(
                        name: "FK_medicalappointment_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalappointment_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "medicalprocedure",
                columns: table => new
                {
                    MedicalProcedureId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicalProcedureDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    DateOfProcedure = table.Column<DateTimeOffset>(nullable: true),
                    Materials = table.Column<string>(type: "varchar(400)", nullable: false),
                    PatientId = table.Column<int>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalprocedure", x => x.MedicalProcedureId);
                    table.ForeignKey(
                        name: "FK_medicalprocedure_doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "doctor",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalprocedure_patient_PatientId",
                        column: x => x.PatientId,
                        principalTable: "patient",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctor_PersonId",
                table: "doctor",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalappointment_DoctorId",
                table: "medicalappointment",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalappointment_PatientId",
                table: "medicalappointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalprocedure_DoctorId",
                table: "medicalprocedure",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalprocedure_PatientId",
                table: "medicalprocedure",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_DoctorId",
                table: "patient",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_patient_PersonId",
                table: "patient",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressId",
                table: "person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_person_BloodTypeId",
                table: "person",
                column: "BloodTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalappointment");

            migrationBuilder.DropTable(
                name: "medicalprocedure");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropTable(
                name: "doctor");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "bloodtype");
        }
    }
}
