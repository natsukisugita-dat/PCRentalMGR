using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCRentalMGR.Migrations
{
    public partial class UpdateEmployeeIDType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals");*/

            /*migrationBuilder.RenameColumn(
                name: "EmployeeID",
                table: "Rentals",
                newName: "EmployeeId");
            */
            /*migrationBuilder.RenameIndex(
                name: "IX_Rentals_EmployeeID",
                table: "Rentals",
                newName: "IX_Rentals_EmployeeId");
            */
            /*migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "Rentals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");*/

            

            /*migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals");*/

            migrationBuilder.DropIndex(
                name: "IX_Rentals_EmployeeId",
                table: "Rentals");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Rentals");

            /*migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Rentals",
                newName: "EmployeeID");
            */
            /*migrationBuilder.RenameIndex(
                name: "IX_Rentals_EmployeeId",
                table: "Rentals",
                newName: "IX_Rentals_EmployeeID");
            */
            /*migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeID",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
