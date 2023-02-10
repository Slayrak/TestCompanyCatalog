using CompanyCatalogue.Helpers;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompanyCatalogue.Controllers
{
    public class TreeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;

        public TreeController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        public async Task<IActionResult> Index()
        {
            var test = await _employeeService.GetLowerLevel(1);

            string json = JsonConvert.SerializeObject(test, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return View(test);
        }


        [HttpGet]
        public async Task<IActionResult> EmployeeTree(int id)
        {
            var test = await _employeeService.GetLowerLevel(id);

            string json = JsonConvert.SerializeObject(test, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                });

            return View("EmployeeTree", test);
        }
    }
}
