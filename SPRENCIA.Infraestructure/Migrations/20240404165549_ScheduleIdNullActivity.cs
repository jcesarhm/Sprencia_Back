using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPRENCIA.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class ScheduleIdNullActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Schedules_ScheduleId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Activities",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Schedules_ScheduleId",
                table: "Activities",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Schedules_ScheduleId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ScheduleId",
                table: "Activities",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Schedules_ScheduleId",
                table: "Activities",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
