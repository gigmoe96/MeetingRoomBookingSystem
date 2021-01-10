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
    class DepartmentService:Service
    {
        private IDepartmentRepository departmentRepository;
        public DepartmentService(IDepartmentRepository repository)
        {
            departmentRepository = repository;
        }
        public List<DepartmentDTO> GET(GetAllDepartmentRequest request)
        {
            List<DepartmentDTO> departmentList = new List<DepartmentDTO>();
            departmentList = departmentRepository.GetAllDepartment();
            return departmentList;
        }
        public DepartmentResponse POST(CreateDepartmentRequest request)
        {
            DepartmentResponse response = new DepartmentResponse();
            DepartmentDTO departmentDetail = new DepartmentDTO();
            departmentDetail = request.DepartmentDetail;
            bool isSuccess = false;
            isSuccess = departmentRepository.SaveDepartment(departmentDetail);
            if (isSuccess)
            {
                response.DepartmentDetail = request.DepartmentDetail;
            }
            else
            {

            }
            return response;
        }
    }
}
