using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace La_mia_pizzeria.Migrations
{
    public partial class UpdateEntityAddCategory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "category_name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_pizza_CategoryId",
                table: "pizza",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_pizza_Categories_CategoryId",
                table: "pizza",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizza_Categories_CategoryId",
                table: "pizza");

            migrationBuilder.DropIndex(
                name: "IX_pizza_CategoryId",
                table: "pizza");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "pizza");

            migrationBuilder.DropColumn(
                name: "category_name",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "IdCategory");
        }
    }
}
