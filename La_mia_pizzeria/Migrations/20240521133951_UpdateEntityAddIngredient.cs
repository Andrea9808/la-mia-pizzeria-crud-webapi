using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace La_mia_pizzeria.Migrations
{
    public partial class UpdateEntityAddIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "pizza",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pizza_IngredientId",
                table: "pizza",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_pizza_Ingredients_IngredientId",
                table: "pizza",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizza_Ingredients_IngredientId",
                table: "pizza");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_pizza_IngredientId",
                table: "pizza");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "pizza");
        }
    }
}
