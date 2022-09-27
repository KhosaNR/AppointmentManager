using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class InitialCreate_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentPerson_AppointmentPersonId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPerson",
                table: "AppointmentPerson");

            migrationBuilder.RenameTable(
                name: "AppointmentPerson",
                newName: "AppointmentPersons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPersons",
                table: "AppointmentPersons",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentPersons_AppointmentPersonId",
                table: "Appointments",
                column: "AppointmentPersonId",
                principalTable: "AppointmentPersons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AppointmentPersons_AppointmentPersonId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppointmentPersons",
                table: "AppointmentPersons");

            migrationBuilder.RenameTable(
                name: "AppointmentPersons",
                newName: "AppointmentPerson");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppointmentPerson",
                table: "AppointmentPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AppointmentPerson_AppointmentPersonId",
                table: "Appointments",
                column: "AppointmentPersonId",
                principalTable: "AppointmentPerson",
                principalColumn: "Id");
        }
    }
}
