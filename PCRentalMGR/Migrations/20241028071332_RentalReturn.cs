using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCRentalMGR.Migrations
{
    public partial class RentalReturn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRented",
                table: "Devices");
            migrationBuilder.AddColumn<bool>(
                name: "IsRented",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false
                );
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Rentals",
                type: "int",
                nullable: true
                );
            migrationBuilder.AddColumn<int>(
                name: "Employee_no",
                table: "Users"
                );
            migrationBuilder.AddColumn<string>(
                name: "Employee_no",
                table: "Users",
                type: "nvarchar(50)",
                nullable: true
                );
        }
    }
}
