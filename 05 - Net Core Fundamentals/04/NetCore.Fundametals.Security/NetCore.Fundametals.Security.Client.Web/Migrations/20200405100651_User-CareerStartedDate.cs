using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Fundametals.Security.Client.Web.Migrations
{
    public partial class UserCareerStartedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerStarted",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CareerStartedDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerStartedDate",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "CareerStarted",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
