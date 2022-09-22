using EmployeeInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Repository
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(int id);
        Employee SaveEmployee(Employee obj);
        Employee UpdateEmployee(Employee upObj);
        Employee DeleteEmployee(int id);
        Employee GetEmployeeByEmail(string email);
        IEnumerable<Department> GetAllDepartment();
        Department SaveDepartment(Department obj);
        Department DeleteDepartment(int id);
    }
}
