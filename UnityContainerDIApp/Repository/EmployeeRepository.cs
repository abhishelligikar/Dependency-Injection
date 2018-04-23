using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnityContainerDIApp.Models;

namespace UnityContainerDIApp.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> objListEmployees = new List<Employee>();
        private int id = 10;

        public EmployeeRepository()
        {
            AddEmployee(new Employee { Id = 1, Name = "Abhishek", EmailId = "abhishelligikar@gmail.com", Salary = 35000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 2, Name = "Chaitra", EmailId = "chai.p321@gmail.com", Salary = 3000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 3, Name = "Pavithra", EmailId = "nspavi1991@gmail.com", Salary = 36000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 4, Name = "Ganesh", EmailId = "munde.ganesh3@gmail.com", Salary = 33500, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 5, Name = "Himanshu", EmailId = "Himanshutyagi@gmail.com", Salary = 32000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 6, Name = "Shashank", EmailId = "kittutheculprit@gmail.com", Salary = 38000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 7, Name = "Swaminand", EmailId = "swaminand@gmail.com", Salary = 30000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 8, Name = "Manish", EmailId = "manishmalhotra@gmail.com", Salary = 38000, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 9, Name = "Manik", EmailId = "maniknain@gmail.com", Salary = 31500, Profile = ".Net Developer" });
            AddEmployee(new Employee { Id = 10, Name = "Shankar", EmailId = "itagishankar@gmail.com", Salary = 28000, Profile = ".Net Developer" });
        }

        public bool AddEmployee(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    throw new ArgumentException("Item is null");
                }
                objEmployee.Id = id++;
                objListEmployees.Add(objEmployee);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteEmployee(Employee objEmployee)
        {
            try
            {
                objListEmployees.RemoveAll(p => p.Id == objEmployee.Id);
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetEmployee(int id)
        {
            try
            {
                return objListEmployees.FirstOrDefault(obj => obj.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return objListEmployees;
        }

        public bool UpdateEmployee(Employee objEmployee)
        {
            try
            {
                if (objEmployee == null)
                {
                    throw new ArgumentNullException("Employee object is null");
                }


                int index = objListEmployees.FindIndex(p => p.Id == objEmployee.Id);
                if (index == -1)
                {
                    return false;
                }
                objListEmployees.RemoveAt(index);
                objListEmployees.Add(objEmployee);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}