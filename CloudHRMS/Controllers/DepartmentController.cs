using CloudHRMS.DAO;
using CloudHRMS.Models.DataModels;
using CloudHRMS.Models.ViewModels;
using CloudHRMS.Utlitity;
using Microsoft.AspNetCore.Mvc;

namespace CloudHRMS.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HRMSDbContext _hRMSDbContext;

        public DepartmentController(HRMSDbContext hRMSDbContext)
        {
            _hRMSDbContext = hRMSDbContext;
        }
        public IActionResult Ilist()
        {
            return View();
        }
        public IActionResult Entry()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entry(DepartmentViewModel departmentViewModel)
        {
            try
            {
                var departmentEntity = new DepartmentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Code = departmentViewModel.Code,
                    Description = departmentViewModel.Description,
                    ExtensionPhone = departmentViewModel.ExtensionPhone,

                    CreatedAt = DateTime.Now,
                    CreatedBy = "system",
                    IsActive = true,
                    Ip = NetworkHelper.GetIpAddress()

                };
                _hRMSDbContext.Departments.Add(departmentEntity);
                _hRMSDbContext.SaveChanges();
                ViewBag.Msg = "Department record is created successfully.";
            }
            catch (Exception e)
            {
                ViewBag.Msg = "Error Occur when department record is created.";
            }
            return View();
        }
    }
}
