using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODO_list.Models;

namespace TODO_list.Controllers
{
    public class HomeController : Controller
    {
        static List<ToDo> toDoItems = new List<ToDo>();        

        public ActionResult Index()
        {            
            return View(toDoItems);
        }

        [HttpGet]
        public ActionResult Create()
        {
            if (toDoItems.Count > 0)
                ViewBag.NewId = toDoItems.Max(t => t.Id) + 1;
            else
                ViewBag.NewId = 1;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDo toDo)
        {
            toDoItems.Add(toDo);
            
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            ToDo t = toDoItems.Find(x => x.Id == id);

            if (t == null)
            {
                return HttpNotFound();
            }
            return View(t);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo t = toDoItems.Find(x => x.Id == id);
            if (t == null)
            {
                return HttpNotFound();
            }

            toDoItems.Remove(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            ToDo t = toDoItems.Find(x => x.Id == id);
            if(t == null)
                return HttpNotFound();

            return View(t);
        }

        [HttpPost]
        public ActionResult Edit(ToDo toDo)
        {
            int index = toDoItems.FindIndex(x => x.Id == toDo.Id);
            toDoItems[index] = toDo;

            return RedirectToAction("Index");
        }
    }
}