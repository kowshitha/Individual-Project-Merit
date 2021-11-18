using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NewBookLendApi.Migrations
{
    public partial class Booklprjt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoytbl",
                columns: table => new
                {
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoytbl_1", x => x.Category);
                });

            migrationBuilder.CreateTable(
                name: "UserTable",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    catergory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    bookname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    returndate = table.Column<DateTime>(type: "date", nullable: false),
                    lendeddate = table.Column<DateTime>(type: "date", nullable: true),
                    bookreqno = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    cost = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTable", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Booktbl",
                columns: table => new
                {
                    bId = table.Column<int>(type: "int", nullable: false),
                    Bookname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    cname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booktbl", x => x.bId);
                    table.ForeignKey(
                        name: "FK__Booktbl__cname__3D5E1FD2",
                        column: x => x.cname,
                        principalTable: "Categoytbl",
                        principalColumn: "Category",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booktbl_cname",
                table: "Booktbl",
                column: "cname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booktbl");

            migrationBuilder.DropTable(
                name: "UserTable");

            migrationBuilder.DropTable(
                name: "Categoytbl");
        }
    }
}
