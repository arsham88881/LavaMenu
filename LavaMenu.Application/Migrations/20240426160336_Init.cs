using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LavaMenu.Application.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categury",
                columns: table => new
                {
                    CateguryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CateguryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SrcCategury = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categury", x => x.CateguryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    productPrice = table.Column<int>(type: "int", nullable: true),
                    IsWithDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountAmountOption = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PictureSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateguryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_product_categury_CateguryId",
                        column: x => x.CateguryId,
                        principalTable: "categury",
                        principalColumn: "CateguryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categury_CateguryName",
                table: "categury",
                column: "CateguryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_CateguryId",
                table: "product",
                column: "CateguryId");

            migrationBuilder.CreateIndex(
                name: "IX_product_ProductTitle",
                table: "product",
                column: "ProductTitle",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UserId",
                table: "Roles",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "categury");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
