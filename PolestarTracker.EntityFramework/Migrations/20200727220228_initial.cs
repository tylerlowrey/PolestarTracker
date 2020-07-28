using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PolestarTracker.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrackingRecords",
                columns: table => new
                {
                    RecordId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProcessName = table.Column<string>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingRecords", x => x.RecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackingRecords");
        }
    }
}
