using Microsoft.EntityFrameworkCore.Migrations;

namespace BookLendingAPI.Migrations
{
    public partial class Booklprjt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoytbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoytbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booktbl",
                columns: table => new
                {
                    bId = table.Column<int>(type: "int", nullable: false),
                    Bookname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booktbl", x => x.bId);
                    table.ForeignKey(
                        name: "FK__Booktbl__cid__267ABA7A",
                        column: x => x.cid,
                        principalTable: "Categoytbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booktbl_cid",
                table: "Booktbl",
                column: "cid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booktbl");

            migrationBuilder.DropTable(
                name: "Categoytbl");
        }
    }
}
