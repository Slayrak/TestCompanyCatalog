using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Models;
using CompanyCatalogue.Models.PassingModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    public class ListController : Controller
    {

        private readonly CatalogueDbContext _dbContext;

        private IEnumerable<Employee> employees;

        private ListPassModel ListPassModel;
        public ListController(CatalogueDbContext catalogueDbContext)
        {
            _dbContext = catalogueDbContext;
        }

        public IActionResult Index()
        {
            ListPassModel = new ListPassModel();

            employees = _dbContext.Employees.ToList();

            ListPassModel.Employees = employees;
            ListPassModel.Number = 20;

            return View(ListPassModel);
        }
    }
}
