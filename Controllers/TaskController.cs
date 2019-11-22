using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.Models.Managers;

namespace ToDoList.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(ToDoes todo)
        {
            DatabaseContext db = new DatabaseContext();

            if (ModelState.IsValid)
            {
                db.ToDoes.Add(todo);

                int result = db.SaveChanges();

                if (result > 0)
                {
                    ViewBag.Result = "Task Saved";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Task Not Saved";
                    ViewBag.Status = "danger";
                }
            }
            

            return View();
        }


        public ActionResult Edit(int? todoId)
        {
            ToDoes todo = null;

            if (todoId != null)
            {
                DatabaseContext db = new DatabaseContext();
                todo = db.ToDoes.Where(x => x.ID == todoId).FirstOrDefault();
            }

            return View();
        }

        [HttpPost]
        public ActionResult Edit(ToDoes model, int? todoId)
        {
            DatabaseContext db = new DatabaseContext();
            ToDoes todo = db.ToDoes.Where(x => x.ID == todoId).FirstOrDefault();

            if (todo != null)
            {
                todo.Date = model.Date;
                todo.Description = model.Description;

                if (ModelState.IsValid)
                {
                    int sonuc = db.SaveChanges();

                    if (sonuc > 0)
                    {
                        ViewBag.Result = "Updated";
                        ViewBag.Status = "success";
                    }
                    else
                    {
                        ViewBag.Result = "Can Not Be Updated";
                        ViewBag.Status = "danger";
                    }
                }

            }

                


            return View();
        }

        public ActionResult Delete(int? todoId)
        {
            ToDoes todo = null;

            if(todoId != null)
            {
                DatabaseContext db = new DatabaseContext();
                todo = db.ToDoes.Where(x => x.ID == todoId).FirstOrDefault();
            }

            return View(todo);
        }


        [HttpPost, ActionName("Delete")]                 //action name ile methodumu Sil ismiyle çağırabilicem.
        public ActionResult SilOk(int? todoId)
        {

            if (todoId != null)
            {
                DatabaseContext db = new DatabaseContext();
                ToDoes todo = db.ToDoes.Where(x => x.ID == todoId).FirstOrDefault();

                db.ToDoes.Remove(todo);
                db.SaveChanges();
            }

            return RedirectToAction("homepage", "Home");  //Silme işlemi Gerçekleştikten sonra başka sayfaya direk yönlendirilicek
        }

    }
}