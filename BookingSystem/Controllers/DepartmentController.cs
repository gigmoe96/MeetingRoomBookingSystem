using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSystem.ServiceClient;
using BookingSystem.ViewModel;
namespace BookingSystem.Controllers
{
    public class DepartmentController : Controller
    {
        private DepartmentServiceClient _departmentServiceClient;
        public DepartmentController()
        {
            _departmentServiceClient = new DepartmentServiceClient();
        }
       
        public ActionResult Departments()
        {
            return View();
        }
        public PartialViewResult _DepartmentListing()
        {
            List<DepartmentViewModel> departmentModelList = new List<DepartmentViewModel>();
            departmentModelList = _departmentServiceClient.GetDepartmentList();
            return PartialView(departmentModelList);
        }
        public PartialViewResult _CreateDepartment()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateDepartment(DepartmentViewModel departmentModel)
        {
            if (ModelState.IsValid)
            {
                DepartmentViewModel departmentDetail = new DepartmentViewModel();
                departmentDetail = _departmentServiceClient.CreateDepartment(departmentModel);
                if (departmentDetail.DepartmentName != null)
                {
                    return RedirectToAction("Departments", "Department");
                }
            }
            return View("Departments");
        }
    }
}