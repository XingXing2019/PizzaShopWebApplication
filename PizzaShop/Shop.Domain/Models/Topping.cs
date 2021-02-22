using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Topping
    {
        public int Id { get; set; }
        public string ToppingName { get; set; }
        public string ToppingSmallImagePath { get; set; }
        public decimal ToppingPrice { get; set; }
        public double ToppingEnergy { get; set; }

        public List<PizzaTopping> PizzaToppings { get; set; }
    }
}