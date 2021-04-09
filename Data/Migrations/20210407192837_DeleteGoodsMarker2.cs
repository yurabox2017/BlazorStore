using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStore.Data.Migrations
{
    public partial class DeleteGoodsMarker2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GoodsMarkers_GoodsMarkerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_GoodsMarkerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "GoodsMarkerId",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GoodsMarkers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsMarkerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "GoodsMarkers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_GoodsMarkerId",
                table: "Products",
                column: "GoodsMarkerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GoodsMarkers_GoodsMarkerId",
                table: "Products",
                column: "GoodsMarkerId",
                principalTable: "GoodsMarkers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
