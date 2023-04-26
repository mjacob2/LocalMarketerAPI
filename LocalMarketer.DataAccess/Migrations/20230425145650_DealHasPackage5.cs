using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DealHasPackage5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Deals_PackageId",
                table: "Deals",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deals_Packages_PackageId",
                table: "Deals",
                column: "PackageId",
                principalTable: "Packages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deals_Packages_PackageId",
                table: "Deals");

            migrationBuilder.DropIndex(
                name: "IX_Deals_PackageId",
                table: "Deals");
        }
    }
}
