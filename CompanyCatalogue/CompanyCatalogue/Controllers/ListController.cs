using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using CompanyCatalogue.Models.PassingModels;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    public class ListController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        private IEnumerable<Employee> employees;

        private ListPassModel ListPassModel;
        public ListController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IActionResult> Index()
        {
            ListPassModel = new ListPassModel();

            employees = await _employeeRepository.GetAll();

            ListPassModel.Employees = employees;
            ListPassModel.Number = 20;

            return View(ListPassModel);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMore(int num)
        {
            ListPassModel = new ListPassModel();

            employees = await _employeeRepository.GetAll();

            ListPassModel.Employees = employees;
            ListPassModel.Number = num;

            return PartialView("PartialTest", ListPassModel);
        }
    }
}
