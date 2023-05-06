using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class LinksInTodo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link1",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link2",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link3",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link4",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Link5",
                table: "ToDos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link1",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Link2",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Link3",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Link4",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Link5",
                table: "ToDos");
        }
    }
}
