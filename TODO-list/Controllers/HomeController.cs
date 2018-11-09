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
            return View();
        }

        [HttpPost]
        public ActionResult Create(ToDo toDo)
        {
            toDoItems.Add(toDo);
            
            return RedirectToAction("Index", toDoItems);
        }

    }
}