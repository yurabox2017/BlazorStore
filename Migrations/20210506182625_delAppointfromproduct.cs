using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStore.Migrations
{
    public partial class delAppointfromproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Appointments_AppointmentId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Appointments_AppointmentId",
                table: "Products",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Appointments_AppointmentId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Appointments_AppointmentId",
                table: "Products",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
