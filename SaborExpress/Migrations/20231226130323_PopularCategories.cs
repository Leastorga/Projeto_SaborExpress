using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaborExpress.Migrations
{
    public partial class PopularCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" + "VALUES('Normal', 'Snack made with normal ingredients')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, Description)" + "VALUES('Natural', 'Snack made with whole and natural ingredients')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
