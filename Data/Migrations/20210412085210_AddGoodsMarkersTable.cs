using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorStore.Data.Migrations
{
    public partial class AddGoodsMarkersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GoodsMarkerId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
