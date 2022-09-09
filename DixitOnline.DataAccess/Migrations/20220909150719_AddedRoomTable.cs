using Microsoft.EntityFrameworkCore.Migrations;

namespace DixitOnline.DataAccess.Migrations
{
    public partial class AddedRoomTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Room",
                table: "Players");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomModel",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomModel", x => x.RoomId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_RoomId",
                table: "Players",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_RoomModel_RoomId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "RoomModel");

            migrationBuilder.DropIndex(
                name: "IX_Players_RoomId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Players");

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
