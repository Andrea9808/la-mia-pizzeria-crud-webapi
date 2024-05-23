using Microsoft.AspNetCore.Mvc.Rendering;

namespace La_mia_pizzeria.Models
{
    public class PizzaFormModel
    {
        public Pizza Pizza { get; set; }
        public List<Category>? Categories { get; set; }
        public List <SelectListItem>? Ingredients { get; set; }
        public List <string>? SelectedIngredients { get; set; }

        public PizzaFormModel() { }
        public PizzaFormModel(Pizza pizza, List<Category> categories) 
        {
            this.Pizza = pizza;
            this.Categories = categories;
        }

        public void CreateIngredients()
        {
            this.Ingredients = new List<SelectListItem>();
            this.SelectedIngredients = new List<string>();
            var ingredientsFromDB = PizzaManager.GetIngredients();
            foreach ( var ingredient in ingredientsFromDB) 
            {
                bool isSelected = this.Pizza.Ingredients?.Any(i => i.Id == ingredient.Id) == true;
                this.Ingredients.Add(new SelectListItem()
                {
                    Text = ingredient._name,
                    Value = ingredient.Id.ToString(),
                    Selected = isSelected
                });
                if (isSelected)
                {
                    //lista degli elementi selezionati
                    this.SelectedIngredients.Add(ingredient.Id.ToString());
                }
            }
        }
    }
}
