using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class addmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Addressid",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    city = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    postalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    houseNumber = table.Column<int>(type: "int", nullable: true),
                    addition = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appointment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Appointment_Dentists_Appointment",
                        column: x => x.Appointment,
                        principalTable: "Dentists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointment_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Roomnumber = table.Column<int>(type: "int", nullable: false),
                    Rented = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AppointmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Note_Appointment_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Treatment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    minutes = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: true),
                    AppointmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatment_Appointment_AppointmentID",
                        column: x => x.AppointmentID,
                        principalTable: "Appointment",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Addressid",
                table: "AspNetUsers",
                column: "Addressid");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Appointment",
                table: "Appointment",
                column: "Appointment");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_PatientId",
                table: "Appointment",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_AppointmentID",
                table: "Note",
                column: "AppointmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatment_AppointmentID",
                table: "Treatment",
                column: "AppointmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_Addressid",
                table: "AspNetUsers",
                column: "Addressid",
                principalTable: "Address",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_Addressid",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Treatment");

            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Addressid",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Addressid",
                table: "AspNetUsers");
        }
    }
}
