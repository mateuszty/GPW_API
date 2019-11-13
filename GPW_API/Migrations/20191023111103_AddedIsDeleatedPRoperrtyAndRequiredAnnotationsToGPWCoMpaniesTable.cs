using Microsoft.EntityFrameworkCore.Migrations;

namespace GPW_API.Migrations
{
    public partial class AddedIsDeleatedPRoperrtyAndRequiredAnnotationsToGPWCoMpaniesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "gpwCompanies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Abrreviation",
                table: "gpwCompanies",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleated",
                table: "gpwCompanies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleated",
                table: "gpwCompanies");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "gpwCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Abrreviation",
                table: "gpwCompanies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
