using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Utlitity;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HRMSDbContext _hRMSDbContext;
        //constructor
        public EmployeeController(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public IActionResult List()
        {
            IList<EmployeeViewModel> employees = _hRMSDbContext.Employees.Where(w => w.IsActive == true).Select(
                s => new EmployeeViewModel()
                {
                    // in view model required daclared
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Address = s.Address,
                    BasicSalary = s.BasicSalary,
                    DOE = s.DOE,
                    DOB = s.DOB,
                    DOR = s.DOR,
                    Email = s.Email,
                    Phone = s.Phone,
                    Gender = s.Gender,
                    DepartmentId = s.DepartmentId,
                    PositionId = s.PositionId,
                }).ToList();

            return View(employees);
        }

        [HttpGet]
        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entry(EmployeeViewModel employeeViewModel)
        {
            try
            {
                // UI ( Viewmodel to datamodel
                //DTO>. data transfer object process in here
                var employeeEntity = new EmployeeEntity()
                {
                    Id = Guid.NewGuid().ToString(), // for primary key auto generation 36 count number and unique number
                    Code = employeeViewModel.Code,
                    Name = employeeViewModel.Name,
                    Email = employeeViewModel.Email,
                    DOE = employeeViewModel.DOE,
                    DOB = employeeViewModel.DOB,
                    DOR = employeeViewModel.DOR,
                    Phone = employeeViewModel.Phone,
                    Address = employeeViewModel.Address,
                    BasicSalary = employeeViewModel.BasicSalary,
                    Gender = employeeViewModel.Gender, // for testing purpose
                    DepartmentId = employeeViewModel.DepartmentId,
                    PositionId = employeeViewModel.PositionId,
                    // for audit purpose column
                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = NetworkHelper.GetIpAddress()
                };
                _hRMSDbContext.Employees.Add(employeeEntity); // collect the entity to the context
                _hRMSDbContext.SaveChanges();// actually save the data to the database
                ViewBag.Msg = "employee record is created successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Msg = "Error Occur when employee record is created.";// show the status message in ENGLISH ONLY (we don't support muti-languages) if you want to show using key file (e.g A is kakyi)
            }
            return View();
        }

        public IActionResult DeleteById(string id)
        {
            try
            {
                EmployeeEntity employee = _hRMSDbContext.Employees.Where(w => w.IsActive && w.Id == id).SingleOrDefault();
                if (employee is not null)
                {
                    employee.IsActive = false;
                    _hRMSDbContext.Employees.Update(employee);
                    _hRMSDbContext.SaveChanges();
                    TempData["Msg"] = "Employee record is delected successfully";

                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error occur when employee record is delected.";

            }
            return RedirectToAction("list");
        }

        public IActionResult Edit(string id)
        {
            EmployeeViewModel employee = _hRMSDbContext.Employees.Where(w => w.IsActive && w.Id == id).Select(
                s => new EmployeeViewModel()
                {
                    // in view model required daclared
                    Id = s.Id,
                    Code = s.Code,
                    Name = s.Name,
                    Address = s.Address,
                    BasicSalary = s.BasicSalary,
                    DOE = s.DOE,
                    DOB = s.DOB,
                    DOR = s.DOR,
                    Email = s.Email,
                    Phone = s.Phone,
                    Gender = s.Gender,
                    DepartmentId = s.DepartmentId,
                    PositionId = s.PositionId,

                }).SingleOrDefault();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(EmployeeViewModel employeeViewModel)
        {
            try
            {
                EmployeeEntity employee = _hRMSDbContext.Employees.Where(w => w.IsActive && w.Id == employeeViewModel.Id).SingleOrDefault(); // take from data server
                if (employee is not null)
                {
                    // change data  UI ( Viewmodel) to datamodel (DB/ Server)
                    employee.Name = employeeViewModel.Name;
                    employee.DOE = employeeViewModel.DOE;
                    employee.DOB = employeeViewModel.DOB;
                    employee.DOR = employeeViewModel.DOR;
                    employee.Phone = employeeViewModel.Phone;
                    employee.Address = employeeViewModel.Address;
                    employee.BasicSalary = employeeViewModel.BasicSalary;
                    employee.Gender = employeeViewModel.Gender;

                    employee.UpdatedAt = DateTime.Now;
                    employee.UpdatedBy = "system";
                    employee.Ip = NetworkHelper.GetIpAddress();

                    _hRMSDbContext.Employees.Update(employee);
                    _hRMSDbContext.SaveChanges();
                    TempData["Msg"] = "Employee record is updated successfully";

                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Error occur when employee record is updated.";

            }
            return RedirectToAction("list");
        }
    }
}
