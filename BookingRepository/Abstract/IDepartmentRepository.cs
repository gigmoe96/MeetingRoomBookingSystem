using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;


namespace BookingRepository.Abstract
{
    public interface IDepartmentRepository
    {
        bool SaveDepartment(DepartmentDTO departmentDetail);
        List<DepartmentDTO> GetAllDepartment();
        
    }
}
