using aggrid_dynamic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace aggrid_dynamic.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext context;

       
        public HomeController(StudentDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public JsonResult GetData()
        {
            var data = context.Students.ToList();
            return new JsonResult(data);
        }
        [HttpPost]

        public IActionResult AddStudent(Student std)
        {
            if (ModelState.IsValid)
            {
                context.Students?.Add(std);
                context.SaveChanges();
                TempData["insert_success"] = "Inserted..";
                return RedirectToAction("Index", "Home");
            }
            return View(std);

        }
       
        [HttpPut]
        public ActionResult EditEmployee(int id, Student edited)
        {
            Student emp = context.Students.Find(id);

            if (emp == null)
            {
                return View();
            }
            emp.FirstName = edited.FirstName;
            emp.LastName = edited.LastName;
            emp.Course = edited.Course;
            emp.PhoneNo = edited.PhoneNo; 
            emp.Age = edited.Age;
            emp.Gender = edited.Gender;
           
            context.SaveChanges();
            return new JsonResult(edited);

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var model = context.Students.Find(Id);
            if(model !=null)
            {
                context.Students.Remove(model);
                context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
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