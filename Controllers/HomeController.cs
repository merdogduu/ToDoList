using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.Models.Managers;
using ToDoList.ViewModels;

namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult homepage()
        {
            DatabaseContext db = new DatabaseContext();

            HomePageViewModel model = new HomePageViewModel();
            model.ToDoes = db.ToDoes.ToList();

            return View(model);
        }
    }
}