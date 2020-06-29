using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.Core.Migrations
{
    public partial class changeNumberToLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Number",
                table: "PhoneNumber",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "PhoneNumber",
                type: "int",
                nullable: false,
                oldClrType: typeof(long));
        }
    }
}
