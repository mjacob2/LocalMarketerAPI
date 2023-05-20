using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ToDoHasForRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForRole",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "ForRole",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForRole",
                table: "ToDos");

            migrationBuilder.AddColumn<string>(
                name: "ForRole",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
