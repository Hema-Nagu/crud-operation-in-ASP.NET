using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace model.Migrations
{
    public partial class EndGamesToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Endgame",
                table: "Endgame");

            migrationBuilder.RenameTable(
                name: "Endgame",
                newName: "Endgames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endgames",
                table: "Endgames",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Endgames",
                table: "Endgames");

            migrationBuilder.RenameTable(
                name: "Endgames",
                newName: "Endgame");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endgame",
                table: "Endgame",
                column: "Id");
        }
    }
}
