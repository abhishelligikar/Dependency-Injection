using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityContainerDIApp.Models;

namespace UnityContainerDIApp.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        bool AddEmployee(Employee objEmployee);
        bool DeleteEmployee(Employee objEmployee);
        bool UpdateEmployee(Employee objEmployee);
    }
}
