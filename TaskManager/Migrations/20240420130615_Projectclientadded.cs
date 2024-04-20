using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager.Migrations
{
    public partial class Projectclientadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientLocations",
                columns: table => new
                {
                    ClientLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientLocationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientLocations", x => x.ClientLocationID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectLists",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeamSize = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientLocationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLists", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_ProjectLists_ClientLocations_ClientLocationID",
                        column: x => x.ClientLocationID,
                        principalTable: "ClientLocations",
                        principalColumn: "ClientLocationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClientLocations",
                columns: new[] { "ClientLocationID", "ClientLocationName" },
                values: new object[,]
                {
                    { 1, "Boston" },
                    { 2, "New Delhi" },
                    { 3, "New Jersy" },
                    { 4, "New York" },
                    { 5, "London" },
                    { 6, "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "ProjectLists",
                columns: new[] { "ProjectID", "Active", "ClientLocationID", "DateOfStart", "ProjectName", "Status", "TeamSize" },
                values: new object[] { 1, true, 2, new DateTime(2017, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hospital Management System", "In Force", 14 });

            migrationBuilder.InsertData(
                table: "ProjectLists",
                columns: new[] { "ProjectID", "Active", "ClientLocationID", "DateOfStart", "ProjectName", "Status", "TeamSize" },
                values: new object[] { 2, true, 1, new DateTime(2018, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Reporting Tool", "Support", 81 });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLists_ClientLocationID",
                table: "ProjectLists",
                column: "ClientLocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectLists");

            migrationBuilder.DropTable(
                name: "ClientLocations");
        }
    }
}
