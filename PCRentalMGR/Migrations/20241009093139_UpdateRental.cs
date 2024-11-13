using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCRentalMGR.Migrations
{
    public partial class UpdateRental : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "Rentals",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Canrental",
                table: "Devices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_DeviceId",
                table: "Rentals",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_EmployeeID",
                table: "Rentals",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Devices_DeviceId",
                table: "Rentals",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Devices_DeviceId",
                table: "Rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_DeviceId",
                table: "Rentals");

            migrationBuilder.DropIndex(
                name: "IX_Rentals_EmployeeID",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "Canrental",
                table: "Devices");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
