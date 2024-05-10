using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavaMenu.Application.Migrations
{
    /// <inheritdoc />
    public partial class FixDeleteOptionInCategury : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_categury_CateguryId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "CateguryId",
                table: "product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_product_categury_CateguryId",
                table: "product",
                column: "CateguryId",
                principalTable: "categury",
                principalColumn: "CateguryId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_categury_CateguryId",
                table: "product");

            migrationBuilder.AlterColumn<int>(
                name: "CateguryId",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_product_categury_CateguryId",
                table: "product",
                column: "CateguryId",
                principalTable: "categury",
                principalColumn: "CateguryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
