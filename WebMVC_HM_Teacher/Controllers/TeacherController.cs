using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC_HM_Teacher.Models;

namespace WebMVC_HM_Teacher.Controllers
{
    public class TeacherController : Controller
    {
        private static List<Teacher> teachers = new List<Teacher>();

        public ActionResult Index()
        {
            return View(teachers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                teacher.Id = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;
                teachers.Add(teacher);
                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        public ActionResult Edit(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            var existingTeacher = teachers.FirstOrDefault(t => t.Id == teacher.Id);
            if (existingTeacher == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                existingTeacher.FirstName = teacher.FirstName;
                existingTeacher.LastName = teacher.LastName;
                existingTeacher.Email = teacher.Email;
                existingTeacher.Subject = teacher.Subject;

                return RedirectToAction("Index");
            }

            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var teacher = teachers.FirstOrDefault(t => t.Id == id);
            if (teacher != null)
            {
                teachers.Remove(teacher);
            }
            return RedirectToAction("Index");
        }
    }
}
