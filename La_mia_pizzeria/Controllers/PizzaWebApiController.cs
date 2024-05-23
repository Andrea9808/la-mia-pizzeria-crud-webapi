using La_mia_pizzeria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace La_mia_pizzeria.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaWebApiController : ControllerBase
    {
        //Pizza by Name ....../api/PizzaWebApi/GetPizzasByName?filter=margherita
        [HttpGet]
        public IActionResult GetPizzasByName(string filter = null)
        {
            using (PizzaContext db = new PizzaContext())
            {
                var pizzas = db.Pizzas.Where(p => p._name.ToLower().Contains(filter.ToLower())).ToList();

                if (pizzas == null)
                {
                    return NotFound("Errore");
                }

                return Ok(pizzas);
            }
        }

        //Pizza by Id ....../api/PizzaWebApi/GetPizzaById?id=4
        [HttpGet]
        public IActionResult GetPizzaById(int id)
        {
            using PizzaContext db = new PizzaContext();
            var pizza = db.Pizzas.Find(id);
            if (pizza == null)
            {
                return NotFound("Errore");
            }
                
            return Ok(pizza);
        }

        //Create ........./api/PizzaWebApi/CreatePizza (settare in POST e crea tramite la sezione row di postman l'elemento)
        [HttpPost]
        public IActionResult CreatePizza([FromBody] Pizza pizza)
        {
            PizzaManager.InsertPizza(pizza, null);
            return Ok();
        }

        //Update ............/api/PizzaWebApi/UpdatePizza/5 (settare in PUT e modificare tramite la sezione row di postman l'elemento)
        [HttpPut("{id}")]
        public IActionResult UpdatePizza(int id, [FromBody] Pizza newPizza)
        {
            using (PizzaContext db = new PizzaContext())
            {
                var Oldpizza = db.Pizzas.Find(id);

                if (Oldpizza == null)
                {
                    return NotFound("Error");
                }

                PizzaManager.UpdatePizza(id, newPizza._name, newPizza._description, newPizza._img, newPizza._price, newPizza.CategoryId, null);
 

                return Ok();
            }
        }

        //Delete ............/api/PizzaWebApi/DeletePizza/312 (id)
        [HttpDelete("{id}")]
        public IActionResult DeletePizza(int id)
        {
            bool found = PizzaManager.DeletePizza(id);
            if (found)
            {
                return Ok();
            }
                
            return NotFound("Error");
        }
    }
}
