using System.Collections.Generic;

namespace Shop.Domain.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string PizzaName { get; set; }
        public string PizzaDescription { get; set; }
        public string PizzaSmallImagePath { get; set; }
        public string PizzaLargeImagePath { get; set; }
        public decimal PizzaPrice { get; set; }
        public double PizzaEnergy { get; set; }

        public List<PizzaTopping> PizzaToppings { get; set; }
    }
}