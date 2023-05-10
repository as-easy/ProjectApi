using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApiApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_item_ParentId",
                table: "item");

            migrationBuilder.AddForeignKey(
                name: "FK_item_item_ParentId",
                table: "item",
                column: "ParentId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_item_item_ParentId",
                table: "item");

            migrationBuilder.AddForeignKey(
                name: "FK_item_item_ParentId",
                table: "item",
                column: "ParentId",
                principalTable: "item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
