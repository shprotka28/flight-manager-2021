using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class patch11updateduserflight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaneID",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "PlaneId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaneId",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "PlaneID",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
