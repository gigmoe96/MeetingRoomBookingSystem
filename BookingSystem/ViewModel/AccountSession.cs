using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookingSystem.ViewModel;

namespace BookingSystem.ViewModel
{
    public class AccountSession
    {
        public bool IsAuthenticated { get; set; }
        public StaffLogInViewModel StaffLogIn { get; set; }
       
    }
}