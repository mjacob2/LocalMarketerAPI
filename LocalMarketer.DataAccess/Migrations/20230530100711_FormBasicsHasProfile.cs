using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormBasicsHasProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FormBasics_ProfileId",
                table: "FormBasics",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_FormBasics_Profiles_ProfileId",
                table: "FormBasics",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormBasics_Profiles_ProfileId",
                table: "FormBasics");

            migrationBuilder.DropIndex(
                name: "IX_FormBasics_ProfileId",
                table: "FormBasics");
        }
    }
}
