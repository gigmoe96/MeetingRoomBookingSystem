using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;

namespace BookingRepository.Abstract
{
    public interface IStaffRepository
    {
        bool SaveStaff(StaffDTO staff);
        List<StaffDTO> GetAllStaff();
        List<StaffDTO> GetStaffLogIn(StaffDTO stafflogin);
        
    }
}
