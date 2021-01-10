using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;
using BookingDomain;
using BookingRepository.Abstract;
using System.Data.SqlClient;
using AutoMapper;

namespace BookingRepository.Concrete
{
    public class StaffRepository : IStaffRepository
    {
  
        private EFDbContext _dbContext = new EFDbContext();
        public bool SaveStaff(StaffDTO staff)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffDTO, Staff>();
            });
            IMapper mapper = config.CreateMapper();
            Staff staffDetail = new Staff();
            staffDetail = mapper.Map<StaffDTO, Staff>(staff);                    
            int resultCount = 0;
            try
            {

                _dbContext.Staffs.Add(staffDetail);
                resultCount = _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }

            if (resultCount > 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public List<StaffDTO> GetAllStaff()
        {
            List<Staff> staffList = _dbContext.Database.SqlQuery<Staff>(@"EXEC GetAllStaff").ToList<Staff>();
            List<StaffDTO> staffListDTO = new List<StaffDTO>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Staff,StaffDTO>();
            });
            IMapper mapper = config.CreateMapper();
            staffListDTO = staffList.Select(x => mapper.Map<StaffDTO>(x)).ToList();
            return staffListDTO;
        }


        public List<StaffDTO> GetStaffLogIn(StaffDTO staffCredential)
        {

            List<Staff> staff = new List<Staff>();
            List<StaffDTO> staffDto = new List<StaffDTO>();
            staff = _dbContext.Database.SqlQuery<Staff>(@"EXEC GetStaffByCredential @UserName,@Password",
            new SqlParameter("UserName", staffCredential.UserName),
            new SqlParameter("Password", staffCredential.Password)).ToList<Staff>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Staff, StaffDTO>();
            });
            IMapper mapper = config.CreateMapper();
            staffDto = staff.Select(x => mapper.Map<StaffDTO>(x)).ToList();
            return staffDto;
        }
        

       
    }
}
