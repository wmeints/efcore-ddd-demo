using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Infrastructure.Data.Migrations
{
    public partial class AddPortionsField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Portions_Maximum",
                table: "Pies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Portions_Minimum",
                table: "Pies",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Portions_Maximum",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "Portions_Minimum",
                table: "Pies");
        }
    }
}
