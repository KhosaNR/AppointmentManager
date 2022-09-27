using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Persons_AppointmentPersonId",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "AppointmentPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppointmentPerson_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_AppointmentPerson_AppointmentPersonId",
                table: "Appointment",
                column: "AppointmentPersonId",
                principalTable: "AppointmentPerson",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_AppointmentPerson_AppointmentPersonId",
                table: "Appointment");

            migrationBuilder.DropTable(
                name: "AppointmentPerson");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Persons_AppointmentPersonId",
                table: "Appointment",
                column: "AppointmentPersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }
    }
}
