using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCRentalMGR.Migrations
{
    public partial class UpdateEmployeeNoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals");*/

            migrationBuilder.DropIndex(
                name: "IX_Rentals_EmployeeID",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Rentals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "Rentals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_EmployeeID",
                table: "Rentals",
                column: "EmployeeID");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");*/
        }
    }
}
