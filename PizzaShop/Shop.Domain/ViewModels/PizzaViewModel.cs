using System.ComponentModel.DataAnnotations;

namespace Shop.Domain.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PizzaName { get; set; }
        public string PizzaDescription { get; set; }
        [Required]
        public string PizzaSmallImagePath { get; set; }
        [Required]
        public string PizzaLargeImagePath { get; set; }
        [Required]
        public decimal PizzaPrice { get; set; }
        [Required]
        public double PizzaEnergy { get; set; }
    }
}