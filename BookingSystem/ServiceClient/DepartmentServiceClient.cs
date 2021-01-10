    using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using BookingSystem.ViewModel;
using Newtonsoft.Json;
using AutoMapper;
using BookingDomain.DTO;
using BookingDomain.RequestModel;

namespace BookingSystem.ServiceClient
{
    public class DepartmentServiceClient
    {
        private HttpClient CreateClient()
        {
            var departmentServiceClient = new HttpClient() { BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceClient"]) };
            departmentServiceClient.DefaultRequestHeaders.Accept.Clear();
            departmentServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return departmentServiceClient;
        }
        public List<DepartmentViewModel> GetDepartmentList()
        {
            List<DepartmentViewModel> departmentList = new List<DepartmentViewModel>();
            HttpClient restClient = CreateClient();
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetAllDepartment/");
            try
            {
                using (var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        departmentList = JsonConvert.DeserializeObject<List<DepartmentViewModel>>(result);
                        return departmentList;
                    }
                    else
                    {
                        return departmentList;
                    }
                }
            }
            catch (Exception ex)
            {


            }
            return departmentList;
        }
        public DepartmentViewModel CreateDepartment(DepartmentViewModel departmentModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DepartmentViewModel, DepartmentDTO>();
            });
            IMapper mapper = config.CreateMapper();
            DepartmentViewModel responseDepartment = new DepartmentViewModel();
            DepartmentDTO departmentDetail = new DepartmentDTO();
            DepartmentRequest request = new DepartmentRequest();
            departmentDetail = mapper.Map<DepartmentViewModel, DepartmentDTO>(departmentModel);
            request.DepartmentDetail = departmentDetail;
            HttpClient restClient = CreateClient();
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "CreateDepartment/");
            try
            {
                using (var response = restClient.PostAsync(UriBuilder.Uri, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        responseDepartment= JsonConvert.DeserializeObject<DepartmentViewModel>(result);
                        return responseDepartment;
                    }
                    else
                    {
                        return responseDepartment;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return responseDepartment;
        }
    }
}