using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace La_mia_pizzeria.Models
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }

        [Column("category_name")]
        public string _name { get; set; }
        public List<Pizza> Pizzas { get; set;}

        public Category() { }


    }
}
