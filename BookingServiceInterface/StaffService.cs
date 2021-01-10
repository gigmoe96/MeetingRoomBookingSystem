using ServiceStack;
using ServiceStack.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingServiceModel;
using BookingDomain;
using BookingDomain.DTO;
using BookingRepository.Abstract;
using AutoMapper;

namespace BookingServiceInterface
{
   public class StaffService: Service
    {
        private IStaffRepository staffRepository;
        public StaffService(IStaffRepository repository)
        {
            staffRepository = repository;
        }
        public List<StaffDTO> GET(GetAllStaffRequest request)
        {
            List<StaffDTO> staffList = new List<StaffDTO>();
            staffList = staffRepository.GetAllStaff() ;
            return staffList;
        }
        public List<StaffDTO> GET(GetStaffByCredentialRequest request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetStaffByCredentialRequest,StaffDTO>();
            });
            StaffDTO staffLogin = new StaffDTO();
            List<StaffDTO> staffDetail = new List<StaffDTO>();
            IMapper mapper = config.CreateMapper();
            staffLogin = mapper.Map<GetStaffByCredentialRequest, StaffDTO>(request);
            staffDetail = staffRepository.GetStaffLogIn(staffLogin);
            return staffDetail ;
        }
        public StaffResponse POST(CreateStaffRequest request)
        {
           
            StaffResponse response = new StaffResponse();
            StaffDTO staffDetail = new StaffDTO();
            staffDetail = request.StaffDetail;           
            bool isSuccess = false;
            isSuccess = staffRepository.SaveStaff(staffDetail);
            if (isSuccess)
            {
                response.StaffDetail = request.StaffDetail;
              
            }
            else
            {
                response.ResponseStatus.Message = "Saving not Successful";
            }
            return response;
        }
    }
}
