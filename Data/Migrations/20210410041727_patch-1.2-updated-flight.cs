using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class patch12updatedflight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountOfBusinessClass",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfEconomyClass",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountOfBusinessClass",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "CountOfEconomyClass",
                table: "Flights");
        }
    }
}
