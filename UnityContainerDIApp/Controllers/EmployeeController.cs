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
                var objEmployeelist = employeeRepository.GetEmployees();
                return View(objEmployeelist);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // GET: Employee/Details/5
        public ActionResult EmployeeDetails(int id)
        {
            try
            {
                var objList = employeeRepository.GetEmployee(id);
                return View(objList);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult AddEmployee(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    throw new ArgumentException("Item is null");
                }
                var boolresult = employeeRepository.AddEmployee(objEmployee);
                if (boolresult)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Employee Cannot be added");
                    return View();
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var objEmployee = employeeRepository.GetEmployee(id);
                return View(objEmployee);
            }
            catch (Exception e)
            {
                throw e;
            }
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
                    return RedirectToAction("Index");
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
            try
            {
                var objEmployee = employeeRepository.GetEmployee(id);
                return View(objEmployee);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    throw new ArgumentNullException("Employee object is null");
                }
                var objEditedEmployee = employeeRepository.DeleteEmployee(objEmployee);
                if (objEditedEmployee)
                {
                    return RedirectToAction("Index");
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
    }
}
