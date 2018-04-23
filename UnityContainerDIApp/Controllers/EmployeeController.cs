using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityContainerDIApp.Models;
using UnityContainerDIApp.Repository;

namespace UnityContainerDIApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;
        
        public EmployeeController(IEmployeeRepository repository)
        {
            this.employeeRepository = repository;
        }

        // GET: Employee
        public ActionResult Index()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET: Employee/Details/5
        public ActionResult EmployeeDetails(int id)
        {
            try
            {
                var objList = employeeRepository.GetEmployees();
                return View(objList);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    throw new ArgumentNullException("Employee object is null");
                }
                var objEditedEmployee = employeeRepository.UpdateEmployee(objEmployee);
                if (objEditedEmployee)
                {
                    return View("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Employee object not edited");
                    return View();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
           


            
           
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
