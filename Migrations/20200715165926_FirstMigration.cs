using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RideShare.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TravelPlan",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<string>(nullable: false),
                    To = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    SeatCount = table.Column<int>(nullable: false),
                    Valid = table.Column<bool>(nullable: false),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelPlan_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TravelGuest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanId = table.Column<int>(nullable: true),
                    GuestId = table.Column<int>(nullable: true),
                    RezervedSeatCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelGuest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TravelGuest_User_GuestId",
                        column: x => x.GuestId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelGuest_TravelPlan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "TravelPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelGuest_GuestId",
                table: "TravelGuest",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelGuest_PlanId",
                table: "TravelGuest",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelPlan_OwnerId",
                table: "TravelPlan",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelGuest");

            migrationBuilder.DropTable(
                name: "TravelPlan");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
