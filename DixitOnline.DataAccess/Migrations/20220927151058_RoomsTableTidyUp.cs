using Microsoft.EntityFrameworkCore.Migrations;

namespace DixitOnline.DataAccess.Migrations
{
    public partial class RoomsTableTidyUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_RoomModel_RoomId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomModel",
                table: "RoomModel");

            migrationBuilder.DropIndex(
                name: "IX_RoomModel_RoomCode",
                table: "RoomModel");

            migrationBuilder.RenameTable(
                name: "RoomModel",
                newName: "Rooms");

            migrationBuilder.AlterColumn<string>(
                name: "RoomCode",
                table: "Rooms",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Rooms_RoomCode",
                table: "Rooms",
                column: "RoomCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Rooms_RoomId",
                table: "Players",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Rooms_RoomId",
                table: "Players");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Rooms_RoomCode",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "RoomModel");

            migrationBuilder.AlterColumn<string>(
                name: "RoomCode",
                table: "RoomModel",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomModel",
                table: "RoomModel",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomModel_RoomCode",
                table: "RoomModel",
                column: "RoomCode",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_RoomModel_RoomId",
                table: "Players",
                column: "RoomId",
                principalTable: "RoomModel",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
