using System.ComponentModel.DataAnnotations;

namespace La_mia_pizzeria.Models
{
    public class Ingredient
    {
        [Key]public int Id { get; set; }
        public string _name { get; set; }

        public List<Pizza> Pizzas { get; set; }
        
        public Ingredient() { }
        public Ingredient( string name)
        {
            _name = name;
        }
    }
}
