using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormServiceHasProfileId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "FormServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FormServices_ProfileId",
                table: "FormServices",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormServices_Profiles_ProfileId",
                table: "FormServices",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormServices_Profiles_ProfileId",
                table: "FormServices");

            migrationBuilder.DropIndex(
                name: "IX_FormServices_ProfileId",
                table: "FormServices");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "FormServices");
        }
    }
}
