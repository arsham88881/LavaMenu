using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavaMenu.Application.Migrations
{
    /// <inheritdoc />
    public partial class modifyEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SrcCategury",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SrcCategury",
                table: "Categories");
        }
    }
}
