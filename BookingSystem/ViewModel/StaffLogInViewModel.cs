using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.ViewModel
{
    public class StaffLogInViewModel
    {
        public string StaffId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}