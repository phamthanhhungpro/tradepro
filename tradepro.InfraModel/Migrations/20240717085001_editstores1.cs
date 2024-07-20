using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tradepro.InfraModel.Migrations
{
    /// <inheritdoc />
    public partial class editstores1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Stores",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_UserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_UserId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "StoreProducts",
                columns: table => new
                {
                    StoreId = table.Column<Guid>(type: "uuid", nullable: false),
                    UeserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProducts", x => new { x.StoreId, x.UeserId });
                    table.ForeignKey(
                        name: "FK_StoreProducts_AspNetUsers_UeserId",
                        column: x => x.UeserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoreProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StoreProducts_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_ProductId",
                table: "StoreProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_UeserId",
                table: "StoreProducts",
                column: "UeserId");
        }
    }
}
