using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updated_cascading_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Profiles_ProfileId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "ProfileId",
                table: "ToDos",
                newName: "DealId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_ProfileId",
                table: "ToDos",
                newName: "IX_ToDos_DealId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Deals_DealId",
                table: "ToDos",
                column: "DealId",
                principalTable: "Deals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_Deals_DealId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "DealId",
                table: "ToDos",
                newName: "ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_DealId",
                table: "ToDos",
                newName: "IX_ToDos_ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_Profiles_ProfileId",
                table: "ToDos",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
