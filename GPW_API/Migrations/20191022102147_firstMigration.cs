using Microsoft.EntityFrameworkCore.Migrations;

namespace GPW_API.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gpwCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Abrreviation = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    PriceChange = table.Column<float>(nullable: false),
                    PriceChangePercent = table.Column<float>(nullable: false),
                    TransactionNumber = table.Column<int>(nullable: false),
                    Turnover = table.Column<float>(nullable: false),
                    OpeningPrice = table.Column<float>(nullable: false),
                    MaxPrice = table.Column<float>(nullable: false),
                    MinPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gpwCompanies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gpwCompanies");
        }
    }
}
