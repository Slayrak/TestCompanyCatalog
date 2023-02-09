using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CompanyCatalogue.Controllers
{
    public class Home1Controller : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;

        public Home1Controller(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            Employee test = await _employeeService.GetLowerLevel(id);

            Employee test2 = await _employeeService.GetFullTree(test);

            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> YourMethod(int id)
        {
            Employee test = await _employeeService.GetLowerLevel(id);

            Employee test2 = await _employeeService.GetFullTree(test);

            return Json(JsonConvert.SerializeObject(test2, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }));
        }
    }
}
