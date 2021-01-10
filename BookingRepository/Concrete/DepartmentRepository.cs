using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRepository.Abstract;
using BookingDomain.DTO;
using BookingDomain;
using AutoMapper;

namespace BookingRepository.Concrete
{
   public class DepartmentRepository:IDepartmentRepository
    {
        private EFDbContext _dbContext = new EFDbContext();
       public bool SaveDepartment(DepartmentDTO departmentDetail)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentDTO, Department>();
            });
            IMapper mapper = config.CreateMapper();
            Department department= new Department();
            department = mapper.Map<DepartmentDTO, Department>(departmentDetail);
            int resultCount = 0;
            try
            {
                _dbContext.Departments.Add(department);
                resultCount=_dbContext.SaveChanges();
            }catch(Exception ex)
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
        public List<DepartmentDTO> GetAllDepartment()
        {
            List<Department> departmentList = _dbContext.Database.SqlQuery<Department>(@"EXEC GetAllDepartment").ToList<Department>();
            List<DepartmentDTO> departmentDTO = new List<DepartmentDTO>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department,DepartmentDTO>();
            });
            IMapper mapper = config.CreateMapper();
            departmentDTO = departmentList.Select(x => mapper.Map<DepartmentDTO>(x)).ToList();
            return departmentDTO;
        }

        
    }
}
