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
    public class StaffServiceClient
    {
        private HttpClient CreateClient()
        {
            var staffServiceClient = new HttpClient() { BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceClient"]) };
            staffServiceClient.DefaultRequestHeaders.Accept.Clear();
            staffServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return staffServiceClient;
        }
        public List<StaffLogInViewModel> GetStaffDetailByCredential(StaffLogInViewModel logInModel)
        {
            List<StaffLogInViewModel> LogInDetail = new List<StaffLogInViewModel>();
            HttpClient restClient = CreateClient();
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetStaffByCredential/" + logInModel.UserName + "/" + logInModel.Password);
            try
            {
                using(var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        LogInDetail = JsonConvert.DeserializeObject<List<StaffLogInViewModel>>(result);
                        return LogInDetail;
                    }
                    else
                    {
                        return LogInDetail;
                    }
                }
            }catch(Exception ex)
            {

            }
            return LogInDetail;
        }
        public List<StaffViewModel> GetStaffList()
        {
            List<StaffViewModel> staffList = new List<StaffViewModel>();
            HttpClient restClient = CreateClient();
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetAllStaff/");
            try
            {
                using(var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        staffList = JsonConvert.DeserializeObject<List<StaffViewModel>>(result);
                        return staffList;
                    }
                    else
                    {
                        return staffList;
                    }
                }
            }catch(Exception ex)
            {


            }
            return staffList;
        }
        public bool CreateStaff(StaffViewModel staffModel)
        {
            bool success = false;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffViewModel, StaffDTO>();
            });
            IMapper mapper = config.CreateMapper();
            StaffViewModel responseStaff = new StaffViewModel();
            StaffDTO staffDetail = new StaffDTO();
            StaffRequest request = new StaffRequest();           
            staffDetail = mapper.Map<StaffViewModel, StaffDTO>(staffModel);
            request.StaffDetail = staffDetail;
            HttpClient restClient = CreateClient();
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "CreateStaff/");
            try
            {
                using(var response = restClient.PostAsync(UriBuilder.Uri,content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        responseStaff = JsonConvert.DeserializeObject<StaffViewModel>(result);
                        success = true;
                    }
                    else
                    {
                        success = false;
                    }
                }
            }catch(Exception ex)
            {

            }
            return success;
        }
    }
}