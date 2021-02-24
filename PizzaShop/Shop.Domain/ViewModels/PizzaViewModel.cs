using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Shop.Domain.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }
        [Required]
        public string PizzaName { get; set; }
        public string PizzaDescription { get; set; }        
        [Required]
        public decimal PizzaPrice { get; set; }
        [Required]
        public double PizzaEnergy { get; set; }

        public IFormFile PizzaSmallImage { get; set; }
        public IFormFile PizzaLargeImage { get; set; }


        public string PizzaSmallImagePath { get; set; }
        public string PizzaLargeImagePath { get; set; }
    }
}