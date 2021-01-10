using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.ViewModel
{
    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public bool Active { get; set; }
    }
}