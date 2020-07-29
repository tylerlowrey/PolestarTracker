using Microsoft.EntityFrameworkCore.Migrations;

namespace PolestarTracker.EntityFramework.Migrations
{
    public partial class ActiveFieldAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "TrackingRecords",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "TrackingRecords");
        }
    }
}
