using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShipmentCode",
                table: "Shipments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShipmentCode",
                table: "Shipments");
        }
    }
}
