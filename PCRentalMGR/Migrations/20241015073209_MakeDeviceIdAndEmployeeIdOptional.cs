using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCRentalMGR.Migrations
{
    public partial class MakeDeviceIdAndEmployeeIdOptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals");*/

            /*migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Rentals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id");*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals");*/

            /*migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "Rentals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            /*migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Employees_EmployeeId",
                table: "Rentals",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);*/
        }
    }
}
