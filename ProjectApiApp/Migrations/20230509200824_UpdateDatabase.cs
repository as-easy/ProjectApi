using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectApiApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProject_project_Projectsid",
                table: "ItemProject");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "project",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "project",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Projectsid",
                table: "ItemProject",
                newName: "ProjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProject_Projectsid",
                table: "ItemProject",
                newName: "IX_ItemProject_ProjectsId");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "project",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "item",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProject_project_ProjectsId",
                table: "ItemProject",
                column: "ProjectsId",
                principalTable: "project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemProject_project_ProjectsId",
                table: "ItemProject");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "project");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "item");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "project",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "project",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProjectsId",
                table: "ItemProject",
                newName: "Projectsid");

            migrationBuilder.RenameIndex(
                name: "IX_ItemProject_ProjectsId",
                table: "ItemProject",
                newName: "IX_ItemProject_Projectsid");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemProject_project_Projectsid",
                table: "ItemProject",
                column: "Projectsid",
                principalTable: "project",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
