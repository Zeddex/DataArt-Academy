using Homework10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Homework10.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Homework10.Controllers
{
    public class HomeController : Controller
    {
        CollegeContext db;
        public HomeController(CollegeContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel
            {
                Students = db.Students.ToList(),
                Groups = db.Groups.ToList()
            };
            return View(ivm);
        }

        [HttpGet]
        public IActionResult Edit(Student student, Group group)
        {
            var groups = db.Groups.ToList();
            ViewBag.Groups = new SelectList(groups, "Id", "Title");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var id = student.Id;
            if (db.Students.Any(s => s.Id == id))
                db.Students.Update(student);
            else
            {
                student.Id = null;          // because of Student.Id auto increment
                db.Students.Add(student);
            }

            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Student student)
        {
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
