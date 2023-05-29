using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalMarketer.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FormBasic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormBasic",
                columns: table => new
                {
                    FormBasicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
                    DealId = table.Column<int>(type: "int", nullable: false),
                    OpenedDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomerService = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AcceptedPaymentMethods = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Voivodeship = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Street = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WebsiteUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    VisitsUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MondayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    MondayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    TuesdayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    WednesdayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    WednesdayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ThursdayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    ThursdayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FridayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FridayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SaturdayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SaturdayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SundayFrom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    SundayTo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Atr1 = table.Column<bool>(type: "bit", nullable: true),
                    Atr2 = table.Column<bool>(type: "bit", nullable: true),
                    Atr3 = table.Column<bool>(type: "bit", nullable: true),
                    Atr4 = table.Column<bool>(type: "bit", nullable: true),
                    Atr5 = table.Column<bool>(type: "bit", nullable: true),
                    Atr6 = table.Column<bool>(type: "bit", nullable: true),
                    Atr7 = table.Column<bool>(type: "bit", nullable: true),
                    Atr8 = table.Column<bool>(type: "bit", nullable: true),
                    Atr9 = table.Column<bool>(type: "bit", nullable: true),
                    Atr10 = table.Column<bool>(type: "bit", nullable: true),
                    Atr11 = table.Column<bool>(type: "bit", nullable: true),
                    Atr12 = table.Column<bool>(type: "bit", nullable: true),
                    Atr13 = table.Column<bool>(type: "bit", nullable: true),
                    Atr14 = table.Column<bool>(type: "bit", nullable: true),
                    Atr15 = table.Column<bool>(type: "bit", nullable: true),
                    Atr16 = table.Column<bool>(type: "bit", nullable: true),
                    Atr17 = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormBasic", x => x.FormBasicId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormBasic");
        }
    }
}
