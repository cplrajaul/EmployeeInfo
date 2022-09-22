using EmployeeInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Repository
{
    public class EmployeeRepository : IEmployee
    {

        private readonly EmployeeDbContext _context;
        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Department> GetAllDepartment()
        {
            return _context.Departments;
        }

        public Department SaveDepartment(Department obj)
        {
            _context.Departments.Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            var employee = _context.Employees.Include(e => e.Department).ToList();
            return employee;
        }


        public Employee GetEmployeeByEmail(string emailAddress)
        {
            Employee employee = _context.Employees.
                Where(e => e.Email == emailAddress).FirstOrDefault();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = _context.Employees.Find(id);
            return emp;
        }


        public Employee SaveEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
            return obj;

        }

        public Employee UpdateEmployee(Employee upObj)
        {
            var emp = _context.Employees.Attach(upObj);
            emp.State = EntityState.Modified;
            _context.SaveChanges();
            return upObj;
        }


        public Employee DeleteEmployee(int id)
        {
            //Employee emp = GetEmployeeById(id);
            Employee emp = _context.Employees.Find(id);
            if (emp!=null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return emp;
        }

        public Department DeleteDepartment(int id)
        {
            Department dept = _context.Departments.Find(id);
            if (dept!=null)
            {
                _context.Departments.Remove(dept);
                _context.SaveChanges();
            }
            return dept;
        }

       
    }
}
