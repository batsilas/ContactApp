using Microsoft.EntityFrameworkCore.Migrations;

namespace ContactApp.Core.Migrations
{
    public partial class addPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "OtherNumber",
                table: "PhoneNumber");

            migrationBuilder.DropColumn(
                name: "TelephoneNumber",
                table: "PhoneNumber");

            migrationBuilder.AddColumn<long>(
                name: "Number",
                table: "PhoneNumber",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "PhoneNumber");

            migrationBuilder.AddColumn<long>(
                name: "MobileNumber",
                table: "PhoneNumber",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "OtherNumber",
                table: "PhoneNumber",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TelephoneNumber",
                table: "PhoneNumber",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
