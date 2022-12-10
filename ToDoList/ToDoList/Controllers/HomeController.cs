using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using ToDoList.Controllers;
using Microsoft.EntityFrameworkCore;
namespace ToDoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        ToDoContext c = new ToDoContext();
        public IActionResult Index()
        {
            var degerler = c.ToDos.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult NewToDo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewToDo(ToDo p)
        {
            c.ToDos.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var d = c.ToDos.Find(id);
                c.ToDos.Remove(d);
                c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var ed = c.ToDos.Find(id);
            return View("Edit", ed);
        }
        public IActionResult EditToDo(ToDo e)
        {
            var et = c.ToDos.Find(e.id);
            et.title = e.title;
            et.todo = e.todo;
            et.time = e.time;
            et.check = e.check;
            c.SaveChanges();
            return RedirectToAction("Index");
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
