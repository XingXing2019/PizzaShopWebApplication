using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Shop.Database;
using Shop.Domain.ViewModels;
using Shop.Service.Admin;

namespace Shop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IPizzaService _pizzaService;
        public AdminController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _pizzaService = new PizzaService(context);
        }

        [HttpGet("pizza/{id?}")]
        public async Task<IActionResult> GetOnePizza(int id) => Ok(await _pizzaService.Get(id));

        [HttpGet("pizza")]
        public async Task<IActionResult> GetAllPizza() => Ok(await _pizzaService.GetAll());

        [HttpPost("pizza")]
        public async Task<IActionResult> CreatePizza(PizzaViewModel vm)
        {
            vm.PizzaSmallImagePath = SaveImage(vm.PizzaSmallImage, "PizzaSlice");
            vm.PizzaLargeImagePath = SaveImage(vm.PizzaLargeImage, "PizzaWhole");
            return Ok(await _pizzaService.Post(vm));
        }


        [HttpPut("pizza")]
        public async Task<IActionResult> UpdatePizza([FromBody] PizzaViewModel vm) => Ok(await _pizzaService.Put(vm));

        [HttpDelete("pizza")]
        public async Task<IActionResult> DeletePizza(int id) => Ok(await _pizzaService.Delete(id));





        private string SaveImage(IFormFile image, string folderName)
        {
            if (image == null) return null;
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "img");
            var filePath = Path.Combine(uploadFolder, folderName, image.FileName);
            image.CopyTo(new FileStream(filePath, FileMode.Create));
            return filePath;
        }
    }
}
