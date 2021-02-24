using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Fluent;
using Shop.Database;
using Shop.Domain.Models;
using Shop.Domain.ViewModels;

namespace Shop.Service.Admin
{
    public class PizzaService : IPizzaService
    {
        private readonly ApplicationDbContext _context;
        private readonly Logger _log;

        public PizzaService(ApplicationDbContext context)
        {
            _context = context;
            _log = LogManager.GetCurrentClassLogger();
        }

        public async Task<PizzaViewModel> Get(int id)
        {
            try
            {
                var pizza = await _context.Pizzas.FindAsync(id);
                if (pizza == null) return null;
                return new PizzaViewModel
                {
                    Id = pizza.Id,
                    PizzaName = pizza.PizzaName,
                    PizzaDescription = pizza.PizzaDescription,
                    PizzaPrice = pizza.PizzaPrice,
                    PizzaEnergy = pizza.PizzaEnergy,
                    PizzaLargeImagePath = pizza.PizzaLargeImagePath,
                    PizzaSmallImagePath = pizza.PizzaSmallImagePath,
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException);
                return null;
            }
        }

        public async Task<List<PizzaViewModel>> GetAll()
        {
            _log.Debug($"{DateTime.Now}: Get all pizzas");
            try
            {
                var pizzas = await _context.Pizzas.ToListAsync();
                var vm = pizzas.Select(x => new PizzaViewModel
                {
                    Id = x.Id,
                    PizzaName = x.PizzaName,
                    PizzaDescription = x.PizzaDescription,
                    PizzaPrice = x.PizzaPrice,
                    PizzaEnergy = x.PizzaEnergy,
                    PizzaLargeImagePath = x.PizzaLargeImagePath,
                    PizzaSmallImagePath = x.PizzaSmallImagePath
                }).ToList();
                return vm;
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException);
                return null;
            }
        }

        public async Task<PizzaViewModel> Post(PizzaViewModel vm)
        {
           


            try
            {
                if (vm == null) return null;
                var pizza = new Pizza
                {
                    PizzaName = vm.PizzaName,
                    PizzaDescription = vm.PizzaDescription,
                    PizzaPrice = vm.PizzaPrice,
                    PizzaEnergy = vm.PizzaEnergy,
                    PizzaLargeImagePath = vm.PizzaLargeImagePath,
                    PizzaSmallImagePath = vm.PizzaSmallImagePath
                };

                _context.Pizzas.Add(pizza);
                await _context.SaveChangesAsync();
                vm.Id = pizza.Id;
                return vm;
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException);
                return null;
            }
        }

        public async Task<PizzaViewModel> Put(PizzaViewModel vm)
        {
            try
            {
                var pizza = new Pizza
                {
                    Id = vm.Id,
                    PizzaName = vm.PizzaName,
                    PizzaDescription = vm.PizzaDescription,
                    PizzaPrice = vm.PizzaPrice,
                    PizzaEnergy = vm.PizzaEnergy,
                    PizzaLargeImagePath = vm.PizzaLargeImagePath,
                    PizzaSmallImagePath = vm.PizzaSmallImagePath
                };
                _context.Attach(pizza);
                _context.Update(pizza);
                await _context.SaveChangesAsync();
                return vm;
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException);
                return null;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var pizza = await _context.Pizzas.FindAsync(id);
                if (pizza == null) return false;
                _context.Pizzas.Remove(pizza);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _log.Error(ex.InnerException);
                return false;
            }
        }
    }
}