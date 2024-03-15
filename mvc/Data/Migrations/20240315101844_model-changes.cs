using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Data.Migrations
{
    /// <inheritdoc />
    public partial class modelchanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_Addressid",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Appointment_AppointmentID",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Appointment_AppointmentID",
                table: "Treatment");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Treatment",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Treatment",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "minutes",
                table: "Treatment",
                newName: "Minutes");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Treatment",
                newName: "AppointmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Treatment_AppointmentID",
                table: "Treatment",
                newName: "IX_Treatment_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Room",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AppointmentID",
                table: "Note",
                newName: "AppointmentId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Note",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Note_AppointmentID",
                table: "Note",
                newName: "IX_Note_AppointmentId");

            migrationBuilder.RenameColumn(
                name: "Addressid",
                table: "AspNetUsers",
                newName: "AddressId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_Addressid",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AddressId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Appointment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Address",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Address",
                newName: "PostalCode");

            migrationBuilder.RenameColumn(
                name: "houseNumber",
                table: "Address",
                newName: "HouseNumber");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Address",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "addition",
                table: "Address",
                newName: "Addition");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Address",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Appointment_AppointmentId",
                table: "Note",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Appointment_AppointmentId",
                table: "Treatment",
                column: "AppointmentId",
                principalTable: "Appointment",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Address_AddressId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Note_Appointment_AppointmentId",
                table: "Note");

            migrationBuilder.DropForeignKey(
                name: "FK_Treatment_Appointment_AppointmentId",
                table: "Treatment");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Treatment",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Treatment",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Minutes",
                table: "Treatment",
                newName: "minutes");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Treatment",
                newName: "AppointmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Treatment_AppointmentId",
                table: "Treatment",
                newName: "IX_Treatment_AppointmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Room",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Note",
                newName: "AppointmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Note",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Note_AppointmentId",
                table: "Note",
                newName: "IX_Note_AppointmentID");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                table: "AspNetUsers",
                newName: "Addressid");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AddressId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_Addressid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointment",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "PostalCode",
                table: "Address",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "HouseNumber",
                table: "Address",
                newName: "houseNumber");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Addition",
                table: "Address",
                newName: "addition");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Appointment",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Patients_PatientId",
                table: "Appointment",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Address_Addressid",
                table: "AspNetUsers",
                column: "Addressid",
                principalTable: "Address",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Note_Appointment_AppointmentID",
                table: "Note",
                column: "AppointmentID",
                principalTable: "Appointment",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatment_Appointment_AppointmentID",
                table: "Treatment",
                column: "AppointmentID",
                principalTable: "Appointment",
                principalColumn: "ID");
        }
    }
}
