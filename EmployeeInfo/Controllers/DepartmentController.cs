using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IEmployee _employeeRepositoy;

        public DepartmentController(IEmployee employeeRepositoy)
        {
            _employeeRepositoy = employeeRepositoy;
        }


        public IActionResult Index()
        {
            return View(_employeeRepositoy.GetAllDepartment());
        }


        [HttpGet]
        public IActionResult Create()
        {
           return View();
        }

        [HttpPost]
        public IActionResult Create(Department obj)
        {
            if (ModelState.IsValid)
            {
                Department dept = new Department()
                {
                    DepartmentName = obj.DepartmentName,
                };
            _employeeRepositoy.SaveDepartment(dept);

            }
            return RedirectToAction("Index", _employeeRepositoy.GetAllDepartment());
        }


        public IActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                Department dept = new Department()
                {
                    DepartmentName = id.ToString(),
                };
                _employeeRepositoy.DeleteDepartment(id);

            }
            return RedirectToAction("Index", _employeeRepositoy.GetAllDepartment());
        }


    }
}
