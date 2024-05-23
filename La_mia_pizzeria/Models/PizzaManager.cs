using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


namespace La_mia_pizzeria.Models
{
    static class PizzaManager
    {
        //LEGGE I DATI
        public static List<Pizza> GetPizzasFromDatabase()
        {
            using (PizzaContext db = new PizzaContext())
            {
                return db.Pizzas.ToList();
            }
        }
        public static List<Pizza> GetPizzas()
        {
            List<Pizza> pizze = new List<Pizza>
            {
                //new Pizza("Margherita", "Pomodoro e Mozzarella", "https://tse2.mm.bing.net/th?id=OIP.ngyqhigAn1u1JdHglgT9qQHaF8&pid=Api&P=0&h=180", 5.00m),
                //new Pizza("Quattro Stagioni", "Pomodoro, Mozzarella, Funghi, Carciofi, Prosciutto Cotto", "https://tse4.mm.bing.net/th?id=OIP.-WRAk4xOUdcb9XgC3DnelgHaFG&pid=Api&P=0&h=180", 7.50m),
                //new Pizza("Diavola", "Pomodoro, Mozzarella, Salame Piccante", "https://www.tastybits.de/wp-content/uploads/2023/01/feurig-scharfe-pizza-diavolo-selber-backen.jpg", 6.50m),
                //new Pizza("Capricciosa", "Pomodoro, Mozzarella, Funghi, Carciofi, Prosciutto Cotto, Olive", "https://www.melarossa.it/wp-content/uploads/2021/02/pizza-capricciosa-ingredienti.jpg?x71872", 8.00m),
                //new Pizza("Prosciutto e Funghi", "Pomodoro, Mozzarella, Prosciutto Cotto, Funghi", "https://tse3.mm.bing.net/th?id=OIP.j_z4MDZ9XVpk2gb0i6xBBwHaEO&pid=Api&P=0&h=180", 6.50m),
                //new Pizza("Quattro Formaggi", "Mozzarella, Gorgonzola, Fontina, Grana Padano", "https://tse3.mm.bing.net/th?id=OIP.b8wlZ8lQD6U25pBZRB_oOgHaE8&pid=Api&P=0&h=180", 8.00m),
                ///new Pizza("Rustica", "Pomodoro, Mozzarella, Salsiccia, Patate, Rosmarino", "https://tse2.mm.bing.net/th?id=OIP.w_QoeH4-rcp9kuwWMVI67QHaFj&pid=Api&P=0&h=180", 7.50m),
                //new Pizza("Tonno e Cipolla", "Pomodoro, Mozzarella, Tonno, Cipolla", "https://tse2.mm.bing.net/th?id=OIP.BxKPPeXp9Ik6baCwRkbUagHaEK&pid=Api&P=0&h=180", 7.00m),
                //new Pizza("Vegetariana", "Pomodoro, Mozzarella, Verdure Grigliate", "https://tse1.mm.bing.net/th?id=OIP.cRd2t4oPlY8Ny30gKs6QyQHaE9&pid=Api&P=0&h=180", 7.50m)
            };
            return pizze;
        }

        //INSERISCE I DATI
        public static void InsertPizza(Pizza pizza, List<string> SelectedIngredients = null)
        {
            using PizzaContext db = new PizzaContext();
            if(SelectedIngredients != null)
            {
                pizza.Ingredients = new List<Ingredient>();

                foreach(var IngredientId in SelectedIngredients)
                {
                    int id = int.Parse(IngredientId);
                    var ingredient = db.Ingredients.FirstOrDefault(i => i.Id == id);
                    pizza.Ingredients.Add(ingredient);
                }

            }
            db.Pizzas.Add(pizza);
            db.SaveChanges();
        }

        //AGGIORNA/MODIFICA I DATI
        public static bool UpdatePizza(int id, string name, string description, 
            string img, decimal price, int? categoryId, List<string> ingredients)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.Where(p => p.Id == id).Include(x => x.Ingredients).FirstOrDefault();

            if (pizza == null)
            {
                return false;
            }

            pizza._name = name;
            pizza._description = description;
            pizza._img = img;
            pizza._price = price;
            pizza.CategoryId = categoryId;

            pizza.Ingredients.Clear();
            if (ingredients != null)
            {
                foreach(var ingredient in ingredients)
                {
                    int ingredientId = int.Parse(ingredient);
                    var ingredientFromDB = db.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
                    pizza.Ingredients.Add(ingredientFromDB);
                }
            }

            //db.Pizzas.Add(pizza);
            db.SaveChanges();

            return true;

        }

        //CANCELLA I DATI
        public static bool DeletePizza(int id)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.Find(id);

            if(pizza == null)
            {
                return false;
            }

            db.Pizzas.Remove(pizza);
            db.SaveChanges();

            return true;
        }


        //prendiamo tutte le categorie
        public static List<Category> GetCategories()
        {
            using PizzaContext db = new PizzaContext();
            return db.Categories.ToList();
        }

        public static List<Ingredient> GetIngredients()
        {
            using PizzaContext db = new PizzaContext();
            return db.Ingredients.ToList();
        }
    }
}
