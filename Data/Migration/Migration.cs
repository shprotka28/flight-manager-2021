using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class FlightDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)    
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFrom = table.Column<string>(nullable: false),
                    LocationTo = table.Column<string>(nullable: false),
                    TakeOffTime = table.Column<DateTime>(nullable: false),
                    LandingTime = table.Column<DateTime>(nullable: false),
                    TypeOfPlane = table.Column<string>(nullable: false),
                    PlaneID = table.Column<int>(nullable: false),
                    NameOfAviator = table.Column<string>(nullable: false),
                    CapacityOfEconomyClass = table.Column<int>(nullable: false),
                    CapacityOfBusinessClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Reservation",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false) 
                        .Annotation("SqlServer:Identity", "1, 1"),
                   FirstName = table.Column<string>(nullable: false),
                   SecondName = table.Column<string>(nullable: false),
                   LastName = table.Column<string>(nullable: false),
                   EGN = table.Column<string>(nullable: false),
                   PhoneNumber = table.Column<string>(nullable: false),
                   Nationality = table.Column<string>(nullable: false),
                   TypeOfTicket = table.Column<string>(nullable: false),
                   Email = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Reservation", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false) 
                        .Annotation("SqlServer:Identity", "1, 1"),
                   UserName = table.Column<string>(nullable: false),
                   Password = table.Column<string>(nullable: false),
                   Email = table.Column<string>(nullable: false),
                   FirstName = table.Column<string>(nullable: false),
                   LastName = table.Column<string>(nullable: false),
                   EGN = table.Column<string>(nullable: false),
                   Address = table.Column<string>(nullable: false),
                   PhoneNumber = table.Column<string>(nullable: false),
                   Role = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.Id);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
            migrationBuilder.DropTable(
                name: "Reservation");
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
