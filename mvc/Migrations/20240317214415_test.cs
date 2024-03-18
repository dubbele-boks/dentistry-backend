using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Room_RoomId",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_RoomId",
                table: "Appointment");

            migrationBuilder.AlterColumn<string>(
                name: "RoomId",
                table: "Appointment",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoomId1",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RoomId1",
                table: "Appointment",
                column: "RoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Room_RoomId1",
                table: "Appointment",
                column: "RoomId1",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Room_RoomId1",
                table: "Appointment");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_RoomId1",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "RoomId1",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Appointment",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_RoomId",
                table: "Appointment",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Room_RoomId",
                table: "Appointment",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
