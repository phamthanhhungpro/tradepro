using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tradepro.InfraModel.Migrations
{
    /// <inheritdoc />
    public partial class cfrela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreProducts_AspNetUsers_UserId",
                table: "StoreProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_AspNetUsers_UserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_UserId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_StoreProducts_UserId",
                table: "StoreProducts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StoreProducts");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_UeserId",
                table: "StoreProducts",
                column: "UeserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProducts_AspNetUsers_UeserId",
                table: "StoreProducts",
                column: "UeserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreProducts_AspNetUsers_UeserId",
                table: "StoreProducts");

            migrationBuilder.DropIndex(
                name: "IX_StoreProducts_UeserId",
                table: "StoreProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Stores",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "StoreProducts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreProducts_UserId",
                table: "StoreProducts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreProducts_AspNetUsers_UserId",
                table: "StoreProducts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_AspNetUsers_UserId",
                table: "Stores",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
