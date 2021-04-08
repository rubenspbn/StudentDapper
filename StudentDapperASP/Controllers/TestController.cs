using BLL.Models;
using BOL.Models;
using StudentDapperASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StudentDapperASP.Controllers
{
    public class TestController : Controller
    {
        private readonly StudentRepository _stuRepo = new StudentRepository();
        private readonly TestRepository _testRepo = new TestRepository();
        // GET: Test
        public async Task<ActionResult> Tests()
        {
            List<TestViewModel> model = new List<TestViewModel>();
            foreach (var item in await _testRepo.GetAllAsync())
            {
                model.Add(new TestViewModel()
                {
                    ID = item.ID,
                    Date = item.Date,
                    StudentID = item.StudentID,
                    Remarks = item.Remarks,
                    AsksTooMuch = item.AsksTooMuch,
                    Name = item.Name,
                    Score = item.Score,
                    StudentName = (await _stuRepo.GetAsync(item.StudentID)).Name
                });
            }
            return View(model);
        }

        // GET: Test/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            Test item = await _testRepo.GetAsync(id);
            string studentName = (await _stuRepo.GetAsync(item.StudentID)).Name;
            TestViewModel model = new TestViewModel()
            {
                StudentName = studentName,
                ID = item.ID,
                Date = item.Date,
                StudentID = item.StudentID,
                Remarks = item.Remarks,
                AsksTooMuch = item.AsksTooMuch,
                Name = item.Name,
                Score = item.Score
            };
            return View(model);
        }

        // GET: Test/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Students = await _stuRepo.GetAllAsync();
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        public async Task<ActionResult> Create(Test test)
        {
            try
            {
                // TODO: Add insert logic here
                await _testRepo.InsertAsync(test);
                return RedirectToAction("Tests");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Test/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            ViewBag.Students = await _stuRepo.GetAllAsync();
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Test test)
        {
            try
            {
                // TODO: Add update logic here
                await _testRepo.UpdateAsync(test);
                return RedirectToAction("Tests");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Test/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            ViewBag.Students = await _stuRepo.GetAllAsync();
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Test test)
        {
            try
            {
                // TODO: Add delete logic here
                await _testRepo.DeleteRowAsync(test.ID);
                return RedirectToAction("Tests");
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
