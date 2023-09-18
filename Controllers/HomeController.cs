using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TODO_MVC.Helpers;
using TODO_MVC.Models;
using TODO_MVC.ViewModels;
using Dapper;

namespace TODO_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;   
        }

        public IActionResult Index()
        {
            TODOListViewModel viewModel = new TODOListViewModel();
            return View("Index", viewModel);
        }

        public IActionResult Edit(int id)
        {
            TODOListViewModel viewModel = new TODOListViewModel();
            viewModel.EditableItem = viewModel.ToDoItem.FirstOrDefault(x => x.Id == id);
            return View("Index", viewModel);
        }

        public IActionResult Delete(int id)
        {
            using (var db = DbHelper.GetConnection())
            {
                ToDoListItem item = db.Get<ToDoListItem>(id);
                if (item != null)
                    db.Delete(item);
                return RedirectToAction("Index");
            }
        }

        public IActionResult CreateUpdate(TODOListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using (var db = DbHelper.GetConnection())
                {
                    if (viewModel.EditableItem.Id <= 0)
                    {
                        viewModel.EditableItem.AddDate = DateTime.Now;
                        db.Insert<ToDoListItem>(viewModel.EditableItem);
                    }
                    else
                    {
                        ToDoListItem dbItem = db.Get<ToDoListItem>(viewModel.EditableItem.Id);
                        var result = TryUpdateModelAsync<ToDoListItem>(dbItem, "EditableItem");
                        db.Update<ToDoListItem>(dbItem);
                    }
                }
                return RedirectToAction("Index");
            }
            else
                return View("Index", new TODOListViewModel());
        }

        public IActionResult ToggleIsDone(int id)
        {
            using (var db = DbHelper.GetConnection())
            {
                ToDoListItem item = db.Get<ToDoListItem>(id);
                if (item != null)
                {
                    item.IsDone = !item.IsDone;
                    db.Update<ToDoListItem>(item);
                }
                return RedirectToAction("Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}