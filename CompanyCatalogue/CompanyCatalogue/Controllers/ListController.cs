using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Helpers;
using CompanyCatalogue.Interfaces;
using CompanyCatalogue.Models;
using CompanyCatalogue.Models.PassingModels;
using Microsoft.AspNetCore.Mvc;
using System;

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

            var page = new PageOptions();

            page.SortProperty = "Name";
            page.SortingDirection = "Ascending";
            page.PageNumber = 1;

            employees = await _employeeRepository.GetPage(page);

            ListPassModel.Employees = employees;

            ListPassModel.Number = (int)Math.Ceiling(await _employeeRepository.CountEntries() / (double)page.PageSize);

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


            //switch (type)
            //{
            //    case "Name":
            //        if(direction == "Ascending")
            //        {
            //            ListPassModel.Employees = employees.OrderBy(x => x.Fullname);
            //        } else
            //        {
            //            ListPassModel.Employees = employees.OrderByDescending(x => x.Fullname);
            //        }
            //        break;
            //    case "Position":
            //        if (direction == "Ascending")
            //        {
            //            ListPassModel.Employees = employees.OrderBy(x => x.Position);
            //        }
            //        else
            //        {
            //            ListPassModel.Employees = employees.OrderByDescending(x => x.Position);
            //        }
            //        break;
            //    case "Salary":
            //        if (direction == "Ascending")
            //        {
            //            ListPassModel.Employees = employees.OrderBy(x => x.Salary);
            //        }
            //        else
            //        {
            //            ListPassModel.Employees = employees.OrderByDescending(x => x.Salary);
            //        }
            //        break;
            //    case "Date of Employment":
            //        if (direction == "Ascending")
            //        {
            //            ListPassModel.Employees = employees.OrderBy(x => x.DateOfEmployment);
            //        }
            //        else
            //        {
            //            ListPassModel.Employees = employees.OrderByDescending(x => x.DateOfEmployment);
            //        }
            //        break;
            //    default:
            //        break;
            //}

            ListPassModel.Number = num;

            return PartialView("PartialTest", employees);
        }
    }
}
