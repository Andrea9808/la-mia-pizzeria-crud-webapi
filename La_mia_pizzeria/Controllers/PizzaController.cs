using La_mia_pizzeria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace La_mia_pizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [Authorize(Roles = "USER, ADMIN")]
        public IActionResult Index()
        {
            using (PizzaContext db = new PizzaContext())
            {
                //List<Pizza> pizze = GetPizzas();

                //prende le pizze direttamente dal db
                List<Pizza> pizze = PizzaManager.GetPizzasFromDatabase();

                //foreach (var pizza in pizze)
                //{
                    //db.Pizzas.Add(pizza);
                //}

                //db.SaveChanges();
                return View("Index", pizze);
            }
        }

        public IActionResult HomePage()
        {
            using (PizzaContext db = new PizzaContext())
            {
                return View("HomePage");
            }
        }

        //SHOW
        [Authorize(Roles = "USER, ADMIN")]
        public IActionResult Show(int id)
        {

            using (PizzaContext db = new PizzaContext())
            {
                Pizza pizzaFound = db.Pizzas.Where(profile => profile.Id == id)
                    .Include(pizza => pizza.Categories)
                    .Include(ingredient => ingredient.Ingredients)
                    .FirstOrDefault();


                if (pizzaFound == null)
                {
                    return View("Error");
                }
                return View(pizzaFound);
            }

        }

        //CREATE
        //with 1 to * and * to *
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create()
        {
            PizzaFormModel model = new PizzaFormModel();
            model.Pizza = new Pizza();
            model.Categories = PizzaManager.GetCategories();
            model.CreateIngredients();
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Create(PizzaFormModel data)
        {
            
            if (!ModelState.IsValid )
            {
                List<Category> categories = PizzaManager.GetCategories();
                data.Categories = categories;
                data.CreateIngredients();
                return View("Create", data);
            }

            PizzaManager.InsertPizza(data.Pizza, data.SelectedIngredients);

            return RedirectToAction("Index");
        }

        //UPDATE
        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id)
        {
            using (PizzaContext db = new PizzaContext())
            {
                var pizza = db.Pizzas.Find(id);

                if(pizza == null)
                {
                    return View("Error");
                }
                else
                {
                    PizzaFormModel model = new PizzaFormModel(pizza, PizzaManager.GetCategories());
                    model.CreateIngredients();
                    return View(model);
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Update(int id, PizzaFormModel data) 
        {
            if (!ModelState.IsValid)
            {
                List<Category> categories = PizzaManager.GetCategories();
                data.Categories = categories;
                data.CreateIngredients();
                return View("Update", data);
            }

            if(PizzaManager.UpdatePizza(id, data.Pizza._name, data.Pizza._description, data.Pizza._img, data.Pizza._price, data.Pizza.CategoryId, data.SelectedIngredients))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

        //DELETE

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "ADMIN")]
        public IActionResult Delete(int id)
        {
            if(PizzaManager.DeletePizza(id))
            {
                return RedirectToAction("Index");
            }
            else 
            { 
                return View("Error"); 
            }
        }

    }
}