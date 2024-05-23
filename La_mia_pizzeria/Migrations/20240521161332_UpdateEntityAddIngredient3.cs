using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace La_mia_pizzeria.Migrations
{
    public partial class UpdateEntityAddIngredient3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPizza_Ingredients_ingredientsId",
                table: "IngredientPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientPizza",
                table: "IngredientPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientPizza_ingredientsId",
                table: "IngredientPizza");

            migrationBuilder.RenameColumn(
                name: "ingredientsId",
                table: "IngredientPizza",
                newName: "IngredientsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientPizza",
                table: "IngredientPizza",
                columns: new[] { "IngredientsId", "PizzasId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_PizzasId",
                table: "IngredientPizza",
                column: "PizzasId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPizza_Ingredients_IngredientsId",
                table: "IngredientPizza",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientPizza_Ingredients_IngredientsId",
                table: "IngredientPizza");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientPizza",
                table: "IngredientPizza");

            migrationBuilder.DropIndex(
                name: "IX_IngredientPizza_PizzasId",
                table: "IngredientPizza");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "IngredientPizza",
                newName: "ingredientsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientPizza",
                table: "IngredientPizza",
                columns: new[] { "PizzasId", "ingredientsId" });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientPizza_ingredientsId",
                table: "IngredientPizza",
                column: "ingredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientPizza_Ingredients_ingredientsId",
                table: "IngredientPizza",
                column: "ingredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
