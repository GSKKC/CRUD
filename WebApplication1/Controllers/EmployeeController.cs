using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Business;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly BEmployee employees = null;
        public EmployeeController()
        {
            employees = new BEmployee();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            List<Employee> employeelist= employees.GetAllData();
            if(employeelist==null)
            {
                ViewBag.Error = "Something Went Wrong, W'll Fix This Soon";
                return View("Error");
            }
            else if(employeelist.Count==0)
            {
                ViewBag.Error = "No Records Found";
                return View(employeelist);
            }
            return View(employeelist);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(employees.GetAllData().Find(x=>x.Id==id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(!ModelState.IsValid)
                {
                return View();
                }
            try
            {
                // TODO: Add insert logic here
                employees.Create(employee);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ExLogger.Logger(ex,@"D:\ErrorLog.txt");
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(employees.GetAllData().Find(x=>x.Id==id));
        }

        
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
             if(!ModelState.IsValid)
                {
                return View();
                }
            try
            {
                // TODO: Add update logic here
                employees.Update(employee);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ExLogger.Logger(ex, @"D:\ErrorLog.txt");
                return View(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(employees.GetAllData().Find(x=>x.Id==id));
        }

        
        [HttpPost]
        public ActionResult Delete(Employee employee)
        {
            try
            {
                // TODO: Add delete logic here
                employees.Delete(employee);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ExLogger.Logger(ex, @"D:\ErrorLog.txt");
                return View(ex.Message);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Ye Description Page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "You Can Contact Me, Below Links are Working, Aaichi Sapat.";

            return View();
        }
    }
}
