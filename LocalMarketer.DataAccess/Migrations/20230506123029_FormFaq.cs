using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormFaq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormFaq",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    Question1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Question6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer6 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFaq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormFaq_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormFaq_ProfileId",
                table: "FormFaq",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormFaq");
        }
    }
}
