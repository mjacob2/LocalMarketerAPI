using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormBasics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormBasic",
                table: "FormBasic");

            migrationBuilder.RenameTable(
                name: "FormBasic",
                newName: "FormBasics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormBasics",
                table: "FormBasics",
                column: "FormBasicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FormBasics",
                table: "FormBasics");

            migrationBuilder.RenameTable(
                name: "FormBasics",
                newName: "FormBasic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormBasic",
                table: "FormBasic",
                column: "FormBasicId");
        }
    }
}
