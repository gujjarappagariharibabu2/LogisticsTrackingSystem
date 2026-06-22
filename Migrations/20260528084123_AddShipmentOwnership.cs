using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LogisticsTrackingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentOwnership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Shipments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_Users_UserId",
                table: "Shipments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_Users_UserId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Shipments");
        }
    }
}
