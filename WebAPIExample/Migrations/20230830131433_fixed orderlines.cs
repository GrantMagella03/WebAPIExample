using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIExample.Migrations
{
    /// <inheritdoc />
    public partial class fixedorderlines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Items",
                newName: "ID");

            migrationBuilder.AddColumn<int>(
                name: "ItemID",
                table: "OrderLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_ItemID",
                table: "OrderLines",
                column: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines");

            migrationBuilder.DropIndex(
                name: "IX_OrderLines_ItemID",
                table: "OrderLines");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "OrderLines");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Items",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderLines",
                type: "nvarchar(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "OrderLines",
                type: "Decimal(11,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "OrderLines",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }
    }
}
