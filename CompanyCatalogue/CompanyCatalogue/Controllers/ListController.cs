using CompanyCatalogue.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    public class ListController : Controller
    {

        private readonly CatalogueDbContext _dbContext;
        public ListController(CatalogueDbContext catalogueDbContext)
        {
            _dbContext = catalogueDbContext;
        }

        public IActionResult Index()
        {
            var res = _dbContext.Employees.ToList();

            return View(res);
        }
    }
}
