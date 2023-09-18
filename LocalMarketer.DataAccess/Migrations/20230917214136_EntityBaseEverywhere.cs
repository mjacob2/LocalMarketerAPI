using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class EntityBaseEverywhere : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ToDoId",
                table: "ToDos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "Profiles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DealId",
                table: "Deals",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ToDos",
                newName: "ToDoId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Profiles",
                newName: "ProfileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Deals",
                newName: "DealId");
        }
    }
}
