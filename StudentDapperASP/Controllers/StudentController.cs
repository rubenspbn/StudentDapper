using BLL.Models;
using BOL.Models;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentDapperASP.Controllers
{
    public class StudentController : Controller
    {
        private StudentRepository _stuRepo = new StudentRepository();
        // GET: Student
        public async Task<ActionResult> Students()
        {
            return View(await _stuRepo.GetAllAsync());
        }
        // GET: Student/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View(await _stuRepo.GetAsync(id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                // TODO: Add insert logic here
                await _stuRepo.InsertAsync(student);
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            return View(await _stuRepo.GetAsync(id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Student student)
        {
            try
            {
                // TODO: Add update logic here
                await _stuRepo.UpdateAsync(student);
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            return View(await _stuRepo.GetAsync(id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Student student)
        {
            try
            {
                // TODO: Add delete logic here
                await _stuRepo.DeleteRowAsync(student.ID);
                return RedirectToAction("Students");
            }
            catch
            {
                return View();
            }
        }
    }
}
