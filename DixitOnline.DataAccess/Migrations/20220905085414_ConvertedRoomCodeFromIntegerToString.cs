using Microsoft.EntityFrameworkCore.Migrations;

namespace DixitOnline.DataAccess.Migrations
{
    public partial class ConvertedRoomCodeFromIntegerToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Room",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 2147483647);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Room",
                table: "Players",
                type: "int",
                maxLength: 2147483647,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
