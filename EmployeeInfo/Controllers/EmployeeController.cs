using EmployeeInfo.Models;
using EmployeeInfo.Repository;
using EmployeeInfo.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeInfo.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IWebHostEnvironment _HostingEnvironment;
        private readonly IEmployee _EmployeeRepository;
        public EmployeeController(IEmployee employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _EmployeeRepository = employeeRepository;
            _HostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            List<Employee> empList = _EmployeeRepository.GetAllEmployee().ToList();
            return View(empList);
        }


        public IActionResult Create()
        {
            ViewBag.Department = _EmployeeRepository.GetAllDepartment();
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel obj)
        {
            if (ModelState.IsValid)
            {
                string unqueFileName = ProcessFileUpload(obj);
                Employee employee = new Employee
                {
                    EmployeeId = obj.EmployeeId,
                    EmployeeName = obj.EmployeeName,
                    PhoneNo = obj.PhoneNo,
                    Email = obj.Email,
                    Address = obj.Address,
                    JoinDate=obj.JoinDate,
                    CreatedTime=obj.CreatedTime,
                    ModifiedTime=obj.ModifiedTime,
                    CreatedDate=obj.CreatedDate,
                    ModifiedDate=obj.ModifiedDate,
                    DepartmentId = obj.DepartmentId,
                    PhotoPath = unqueFileName
                };
                _EmployeeRepository.SaveEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Departments = _EmployeeRepository.GetAllDepartment();
                return View();
            }
        }

        private string ProcessFileUpload(EmployeeViewModel obj)
        {
            string unqueFileName = null;
            if (obj.Photo != null)
            {
                string uploadFolder = Path.Combine(_HostingEnvironment.WebRootPath, "images");
                unqueFileName = Guid.NewGuid().ToString() + "_" + obj.Photo.FileName;
                string filePath = Path.Combine(uploadFolder, unqueFileName);
                using (var FileStream = new FileStream(filePath, FileMode.Create))
                {
                    obj.Photo.CopyTo(FileStream);
                }
            }
            return unqueFileName;
        }



        public IActionResult Edit(int id)
        {
            ViewBag.Department = _EmployeeRepository.GetAllDepartment();
            Employee emp = _EmployeeRepository.GetEmployeeById(id);
            EmployeeViewModel viewModel = GetEditemployee(emp);
            return View(viewModel);
        }

        private EmployeeViewModel GetEditemployee(Employee emp)
        {
            EmployeeViewModel editemp = new EmployeeViewModel
            {
                EmployeeId = emp.EmployeeId,
                EmployeeName = emp.EmployeeName,
                PhoneNo = emp.PhoneNo,
                Email = emp.Email,
                Address = emp.Address,
                JoinDate = emp.JoinDate,
                CreatedTime = emp.CreatedTime,
                ModifiedTime = emp.ModifiedTime,
                CreatedDate = emp.CreatedDate,
                ModifiedDate = emp.ModifiedDate,
                DepartmentId = emp.DepartmentId,
                ExistingPhotoPath = emp.PhotoPath
            };
            return editemp;
        }


        [HttpPost]
        public IActionResult Edit(EmployeeViewModel obj)
        {
            Employee empObj = _EmployeeRepository.GetEmployeeById(obj.EmployeeId);
            if (ModelState.IsValid)
            {
                empObj.EmployeeName = obj.EmployeeName;
                empObj.PhoneNo = obj.PhoneNo;
                empObj.Email = obj.Email;
                empObj.Address = obj.Address;
                empObj.JoinDate = obj.JoinDate;
                empObj.CreatedTime = obj.CreatedTime;
                empObj.ModifiedTime = obj.ModifiedTime;
                empObj.CreatedDate = obj.CreatedDate;
                empObj.ModifiedDate = obj.ModifiedDate;
                empObj.DepartmentId = obj.DepartmentId;
                if (obj.Photo != null)
                {
                    empObj.PhotoPath = ProcessFileUpload(obj);
                    if (obj.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "images", obj.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                }
                _EmployeeRepository.UpdateEmployee(empObj);
                return RedirectToAction("Index");
            }
            EmployeeViewModel viewModel = GetEditemployee(empObj);
            return View(viewModel);
        }


        public IActionResult Delete(int id)
        {
            //This line for showing department name in delete views
            ViewBag.Departments = _EmployeeRepository.GetAllDepartment();

            Employee delemp = _EmployeeRepository.GetEmployeeById(id);
            EmployeeViewModel viewModel = GetEditemployee(delemp);
            return View(viewModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Employee delempObj = _EmployeeRepository.GetEmployeeById(id);
            if (delempObj.PhotoPath != null)
            {
                string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "images", delempObj.PhotoPath);
                System.IO.File.Delete(filePath);
                Employee emp = _EmployeeRepository.DeleteEmployee(id);
                return RedirectToAction("Index");
            }
            EmployeeViewModel viewModel = GetEditemployee(delempObj);
            return View(viewModel);
        }



        public IActionResult Details(int id)
        {
            //This line for showing department name in delete views
            ViewBag.Departments = _EmployeeRepository.GetAllDepartment();


            Employee detObj = _EmployeeRepository.GetEmployeeById(id);
            return View(detObj);
        }
    }
}
