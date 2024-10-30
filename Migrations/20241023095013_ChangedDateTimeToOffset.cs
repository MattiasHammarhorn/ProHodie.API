using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProHodie.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangedDateTimeToOffset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Activities");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndTime",
                table: "Activities",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartTime",
                table: "Activities",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Activities");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Activities");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Activities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
