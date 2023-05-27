using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ProfileGoogleProfileIdCanBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_GoogleProfileId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "GoogleProfileId",
                table: "Profiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GoogleProfileId",
                table: "Profiles",
                column: "GoogleProfileId",
                unique: true,
                filter: "[GoogleProfileId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profiles_GoogleProfileId",
                table: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "GoogleProfileId",
                table: "Profiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_GoogleProfileId",
                table: "Profiles",
                column: "GoogleProfileId",
                unique: true);
        }
    }
}
