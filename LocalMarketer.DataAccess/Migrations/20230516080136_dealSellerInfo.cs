using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class dealSellerInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SellerFullName",
                table: "Deals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Deals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SellerFullName",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Deals");
        }
    }
}
