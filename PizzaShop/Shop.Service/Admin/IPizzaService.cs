using System.Collections.Generic;
using System.Threading.Tasks;
using Shop.Domain.ViewModels;

namespace Shop.Service.Admin
{
    public interface IPizzaService
    {
        Task<PizzaViewModel> Get(int id);
        Task<List<PizzaViewModel>> GetAll();
        Task<PizzaViewModel> Post(PizzaViewModel vm);
        Task<PizzaViewModel> Put(PizzaViewModel vm);
        Task<bool> Delete(int id);
    }
}