using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Shipments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveredDate",
                table: "Shipments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDeliveryDate",
                table: "Shipments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "DeliveredDate",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "ExpectedDeliveryDate",
                table: "Shipments");
        }
    }
}
