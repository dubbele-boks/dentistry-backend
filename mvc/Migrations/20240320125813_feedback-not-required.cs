using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mvc.Migrations
{
    /// <inheritdoc />
    public partial class feedbacknotrequired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Feedback_FeedbackId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "Appointment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Feedback_FeedbackId",
                table: "Appointment",
                column: "FeedbackId",
                principalTable: "Feedback",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Feedback_FeedbackId",
                table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "FeedbackId",
                table: "Appointment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Feedback_FeedbackId",
                table: "Appointment",
                column: "FeedbackId",
                principalTable: "Feedback",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
