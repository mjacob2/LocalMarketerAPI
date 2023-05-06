using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormFaqJsonIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFaq_Profiles_ProfileId",
                table: "FormFaq");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormFaq",
                table: "FormFaq");

            migrationBuilder.RenameTable(
                name: "FormFaq",
                newName: "FormFaqs");

            migrationBuilder.RenameIndex(
                name: "IX_FormFaq_ProfileId",
                table: "FormFaqs",
                newName: "IX_FormFaqs_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormFaqs",
                table: "FormFaqs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormFaqs_Profiles_ProfileId",
                table: "FormFaqs",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FormFaqs_Profiles_ProfileId",
                table: "FormFaqs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormFaqs",
                table: "FormFaqs");

            migrationBuilder.RenameTable(
                name: "FormFaqs",
                newName: "FormFaq");

            migrationBuilder.RenameIndex(
                name: "IX_FormFaqs_ProfileId",
                table: "FormFaq",
                newName: "IX_FormFaq_ProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormFaq",
                table: "FormFaq",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormFaq_Profiles_ProfileId",
                table: "FormFaq",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
