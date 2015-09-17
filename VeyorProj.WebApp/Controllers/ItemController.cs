using Serilog;
using System.Web.Mvc;
using VeyorProj.Lib;
using VeyorProj.WebApp.Data;
using VeyorProj.WebApp.Models;
using VeyorProj.WebApp.Models.Entity;

namespace VeyorProj.WebApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ILogger logger;
        private readonly IDbRepo _repo;

        public ItemController(IDbRepo repo)
        {
            _repo = repo;
            logger = AppLogger.Logger.ForContext<ItemController>();
        }

        [HttpGet]
        public ActionResult Show(int id)
        {
            logger.Debug("Running method: {method} with parameter id: {id}", "Show", id);

            var model = new VmItemShow
            {
                Item = _repo.GetItem(id)
            };

            logger.Information("Model constructed: {@model}", model);

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            logger.Debug("Running method: {method} with parameter id: {id}", "Edit", id);

            var model = Map(_repo.GetItem(id));

            logger.Information("Model constructed: {@model}", model);

            return View(model);
        }

        [HttpGet]
        public ActionResult New()
        {
            logger.Debug("Running method: {method}", "New");

            var model = new VmItemNew();

            logger.Information("Model constructed: {@model}", model);

            return View(model);
        }


        [HttpPost]
        public ActionResult Add(VmItemNew inputModel)
        {
            logger.Debug("Running method: {method} with parameter model data: {@inputModel}", "Add", inputModel);

            var item = Map(inputModel);

            _repo.AddItem(item);

            logger.Information("Added item {@item}", item);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Update(VmItemEdit inputModel)
        {
            logger.Debug("Running method: {method} with parameter model data: {@inputModel}", "Update", inputModel);

            var item = Map(inputModel);

            _repo.UpdateItem(item);

            logger.Information("Updated item {@item}", item);

            return RedirectToAction("Index", "Home");
        }


        //========================================================//

        private static VmItemEdit Map(item i)
        {
            return new VmItemEdit
            {
                rowid = i.rowid,
                name = i.name,
                description = i.description,
                rating = i.rating,
                price = i.price
            };
        }

        private static item Map(VmItemEdit i)
        {
            return new item
            {
                rowid = i.rowid,
                name = i.name,
                description = i.description,
                rating = i.rating,
                price = i.price
            };
        }

        private static item Map(VmItemNew i)
        {
            return new item
            {
                rowid = 0,
                name = i.name,
                description = i.description,
                rating = i.rating,
                price = i.price
            };
        }
    }
}