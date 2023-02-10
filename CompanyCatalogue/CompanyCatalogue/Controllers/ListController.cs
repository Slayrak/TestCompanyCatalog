using CompanyCatalogue.Helpers;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    [Authorize]
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

            var page = new PageOptions();

            page.SortProperty = "Name";
            page.SortingDirection = "Ascending";
            page.PageNumber = 1;

            employees = await _employeeRepository.GetPage(page);

            ListPassModel.Employees = employees;

            ListPassModel.Number = (int)Math.Ceiling(await _employeeRepository.CountEntries() / (double)page.PageSize);

            ListPassModel.MaxSalary = await _employeeRepository.GetMaxSalary();

            ListPassModel.MinSalary = await _employeeRepository.GetMinSalary();

            return View(ListPassModel);
        }

        [HttpGet]
        public async Task<IActionResult> LoadMore(int num, string type, string direction)
        {
            var page = new PageOptions();

            page.SortProperty = type;
            page.SortingDirection = direction;
            page.PageNumber = num;

            employees = await _employeeRepository.GetPage(page);
            ListPassModel = new ListPassModel();
            ListPassModel.Employees = employees;

            ListPassModel.Number = num;

            return PartialView("PartialTest", employees);
        }

        [HttpPost]
        public async Task<IActionResult> GetPage(FilterOptions filter, int num, string type, string direction)
        {
            var page = new PageOptions();

            var model = filter;

            page.SortProperty = type;
            page.SortingDirection = direction;
            page.PageNumber = num;

            employees = await _employeeRepository.GetFilteredPage(page, filter);
            return PartialView("PartialTest", employees);
        }

    }
}
