using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Fundametals.Security.Identity.Client.Web.Data.Migrations
{
    public partial class UserCareerStarted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CareerStarted",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CareerStarted",
                table: "AspNetUsers");
        }
    }
}
