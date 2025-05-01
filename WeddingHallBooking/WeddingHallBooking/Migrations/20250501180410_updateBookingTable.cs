using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeddingHallBooking.Migrations
{
    /// <inheritdoc />
    public partial class updateBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Bookings",
                newName: "Extras");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Extras",
                table: "Bookings",
                newName: "UserName");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
