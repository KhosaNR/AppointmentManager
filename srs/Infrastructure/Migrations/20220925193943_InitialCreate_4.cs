using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AppointmentPerson_AppointmentPersonId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AppointmentPerson_Persons_Id",
                table: "AppointmentPerson");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment");

            migrationBuilder.RenameTable(
                name: "Appointment",
                newName: "Appointments");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_AppointmentPersonId",
                table: "Appointments",
                newName: "IX_Appointments_AppointmentPersonId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AppointmentPerson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppointmentPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppointmentPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AppointmentPerson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AppointmentPerson",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentPerson_AppointmentPersonId",
                table: "Appointments",
                column: "AppointmentPersonId",
                principalTable: "AppointmentPerson",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentPerson_AppointmentPersonId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Appointments",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AppointmentPerson");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppointmentPerson");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppointmentPerson");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AppointmentPerson");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AppointmentPerson");

            migrationBuilder.RenameTable(
                name: "Appointments",
                newName: "Appointment");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_AppointmentPersonId",
                table: "Appointment",
                newName: "IX_Appointment_AppointmentPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Appointment",
                table: "Appointment",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AppointmentPerson_AppointmentPersonId",
                table: "Appointment",
                column: "AppointmentPersonId",
                principalTable: "AppointmentPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppointmentPerson_Persons_Id",
                table: "AppointmentPerson",
                column: "Id",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
