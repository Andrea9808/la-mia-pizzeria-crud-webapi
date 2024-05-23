using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace La_mia_pizzeria.Migrations
{
    public partial class UpdateEntityAddIngredient2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_pizza_Ingredients_IngredientId",
                table: "pizza");

            migrationBuilder.DropIndex(
                name: "IX_pizza_IngredientId",
                table: "pizza");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "pizza");

            migrationBuilder.CreateTable(
                name: "IngredientPizza",
                columns: table => new
                {
                    PizzasId = table.Column<int>(type: "int", nullable: false),
                    ingredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientPizza", x => new { x.PizzasId, x.ingredientsId });
                    table.ForeignKey(
                        name: "FK_IngredientPizza_Ingredients_ingredientsId",
                        column: x => x.ingredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientPizza_pizza_PizzasId",
                        column: x => x.PizzasId,
                        principalTable: "pizza",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_ingredientsId",
                table: "IngredientPizza",
                column: "ingredientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientPizza");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "pizza",
                type: "int",
                nullable: true);

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
    }
}
