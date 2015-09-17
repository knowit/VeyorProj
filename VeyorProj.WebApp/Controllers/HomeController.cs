using Serilog;
using System.Web.Mvc;
using VeyorProj.Lib;
using VeyorProj.WebApp.Data;
using VeyorProj.WebApp.Models;

namespace VeyorProj.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly IDbRepo _repo;

        public HomeController(IDbRepo repo)
        {
            _repo = repo;
            logger = AppLogger.Logger.ForContext<HomeController>();
        }

        [HttpGet]
        public ActionResult Index()
        {
            logger.Debug("Running method {method}", "Index");

            var model = new VmHomeIndex
            {
                Items = _repo.GetItems()
            };

            logger.Information("Viewmodel constructed. {@model}", model);


            return View(model);
        }
    }
}
