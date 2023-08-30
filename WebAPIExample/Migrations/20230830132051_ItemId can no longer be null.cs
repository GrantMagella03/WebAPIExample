using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPIExample.Migrations
{
    /// <inheritdoc />
    public partial class ItemIdcannolongerbenull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "OrderLines",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "OrderLines",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLines_Items_ItemID",
                table: "OrderLines",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ID");
        }
    }
}
