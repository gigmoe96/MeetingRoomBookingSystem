using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSystem.ViewModel;
using BookingSystem.ServiceClient;
 
namespace BookingSystem.Controllers
{
    public class StaffController : Controller
    {
        private StaffServiceClient _staffServiceClient;
        private DepartmentServiceClient _departmentServiceClient;
        public StaffController()
        {
            _staffServiceClient =new StaffServiceClient();
            _departmentServiceClient = new DepartmentServiceClient();
        }
        public ActionResult LogIn()
        {
            
            return View();
        }
      [HttpPost]
      public ActionResult LogIn( StaffLogInViewModel staffLogInViewModel)
        {
            if (ModelState.IsValid)
            {
                AccountSession accountSession = new AccountSession();
                List<StaffLogInViewModel> staffModelList = new List<StaffLogInViewModel>();
                StaffLogInViewModel staffModel = new StaffLogInViewModel();               
                staffModelList = _staffServiceClient.GetStaffDetailByCredential(staffLogInViewModel);
                foreach (var item in staffModelList)
                {
                    staffModel = item;
                }
                if (staffModel.UserName!=null)
                {
                    accountSession.IsAuthenticated = true;
                    accountSession.StaffLogIn = staffModel;
                    Session["AccountSession"] = accountSession;
                    return RedirectToAction("BookRoom", "Booking", new { StaffId =staffModel.StaffId });
                
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Sorry! Invalid user name or password.");
                    return View(staffLogInViewModel);
                }
            }
            return View();
        }
        public ActionResult Users()
        {
           

            return View();
        }
        public PartialViewResult _UserListing()
        {
            List<StaffViewModel> staffModelList = new List<StaffViewModel>();
            staffModelList = _staffServiceClient.GetStaffList();

            return PartialView(staffModelList);
        }
        public PartialViewResult _CreateUser()
        {
            ViewBag.UserRole = UserRole;
            List<DepartmentViewModel> DepartmentList = new List<DepartmentViewModel>();
            DepartmentList = _departmentServiceClient.GetDepartmentList();
            var departmentSelectList = new SelectList(DepartmentList, "DepartmentId", "DepartmentName");
            ViewBag.DepartmentList = departmentSelectList;
            return PartialView();
        }

        //[HttpPost]
        //public  ActionResult CreateUser(StaffViewModel staffModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        StaffViewModel staffDetail = new StaffViewModel();
        //        staffDetail = _staffServiceClient.CreateStaff(staffModel);
        //        if (staffDetail.UserName != null)
        //        {
        //            return RedirectToAction("Users", "Staff");
        //        }
                
        //    }
        //    return View("Users");
        //}
        public JsonResult AddUser(StaffViewModel staffModel)
        {
            bool success = false;
            string message = null;
            if (ModelState.IsValid)
            {
                //StaffViewModel staffDetail = new StaffViewModel();
                bool returnValue = false;
                returnValue = _staffServiceClient.CreateStaff(staffModel);
                if (returnValue)
                {
                    success = true;
                    message = "Saving Successful";
                }
                else
                {
                    success = false;
                    message = "Try Again";
                }
            }
            return this.Json(new { success, message });
        }

      

        public List<SelectListItem> UserRole
        {
            get
            {
                List<SelectListItem> UserRole = new List<SelectListItem>();
                UserRole.Add(new SelectListItem { Text = "Admin", Value = "Admin", Selected = true });
                UserRole.Add(new SelectListItem { Text = "Staff", Value = "staff" });
                return UserRole;
            }
        }
    }
}