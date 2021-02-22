using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Database;
using Shop.Domain.ViewModels;
using Shop.Service.Admin;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IPizzaService _pizzaService;
        public AdminController(ApplicationDbContext context)
        {
            _pizzaService = new PizzaService(context);
        }

        [HttpGet("pizza/{id?}")]
        public async Task<IActionResult> GetOnePizza(int id) => Ok(await _pizzaService.Get(id));

        [HttpGet("pizza")]
        public async Task<IActionResult> GetAllPizza() => Ok(await _pizzaService.GetAll());

        [HttpPost("pizza")]
        public async Task<IActionResult> CreatePizza(PizzaViewModel vm) => Ok(await _pizzaService.Post(vm));

        [HttpPut("pizza")]
        public async Task<IActionResult> UpdatePizza(PizzaViewModel vm) => Ok(await _pizzaService.Put(vm));

        [HttpDelete("pizza")]
        public async Task<IActionResult> DeletePizza(int id) => Ok(await _pizzaService.Delete(id));
    }
}
