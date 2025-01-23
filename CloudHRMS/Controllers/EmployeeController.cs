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
        public IActionResult Ilist()
        {
            return View();
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
                    Gender = employeeViewModel.Gender,
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
    }
}
