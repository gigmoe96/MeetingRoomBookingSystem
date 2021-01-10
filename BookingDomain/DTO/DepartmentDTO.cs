using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain.DTO
{
    public class DepartmentDTO
    {     
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
       
        public string DepartmentCode { get; set; }
       
        public Boolean Active { get; set; }
    }
}
