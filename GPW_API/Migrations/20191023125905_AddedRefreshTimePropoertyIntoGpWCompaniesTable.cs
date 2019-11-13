using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPW_API.Migrations
{
    public partial class AddedRefreshTimePropoertyIntoGpWCompaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTime",
                table: "gpwCompanies",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTime",
                table: "gpwCompanies");
        }
    }
}
