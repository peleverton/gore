using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gore.Infra.Data.Migrations
{
    public partial class AddNeighborhoodAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_address_AddressId",
                table: "person");

            migrationBuilder.DropTable(
                name: "medicalappointment");

            migrationBuilder.DropTable(
                name: "medicalprocedure");

            migrationBuilder.DropTable(
                name: "patient");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "bloodtype");

            migrationBuilder.RenameColumn(
                name: "complement",
                table: "address",
                newName: "Complement");

            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "person",
                type: "long",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeId",
                table: "person",
                nullable: true,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "person",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BloodTypeId",
                table: "bloodtype",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Cep",
                table: "address",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "varchar(100",
                table: "address",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_person_address_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_address_AddressId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "varchar(100",
                table: "address");

            migrationBuilder.RenameColumn(
                name: "Complement",
                table: "address",
                newName: "complement");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "person",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "long");

            migrationBuilder.AlterColumn<Guid>(
                name: "BloodTypeId",
                table: "person",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "person",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<Guid>(
                name: "BloodTypeId",
                table: "bloodtype",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "bloodtype",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Cep",
                table: "address",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "patient",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<bool>(type: "bit(1)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    Email = table.Column<string>(type: "varchar(100)", nullable: true),
                    Height = table.Column<double>(type: "double", nullable: false),
                    PersonId = table.Column<int>(nullable: true),
                    Picture = table.Column<string>(type: "varchar(100)", nullable: true),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    Weight = table.Column<double>(type: "double", nullable: false)
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
                    DoctorId = table.Column<int>(nullable: true),
                    PatientId = table.Column<int>(nullable: true),
                    SchedulingDate = table.Column<DateTimeOffset>(nullable: true)
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
                    DateOfProcedure = table.Column<DateTimeOffset>(nullable: true),
                    DoctorId = table.Column<int>(nullable: true),
                    Materials = table.Column<string>(type: "varchar(400)", nullable: false),
                    MedicalProcedureDescription = table.Column<string>(type: "varchar(250)", nullable: false),
                    PatientId = table.Column<int>(nullable: true)
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

            migrationBuilder.AddForeignKey(
                name: "FK_person_address_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
