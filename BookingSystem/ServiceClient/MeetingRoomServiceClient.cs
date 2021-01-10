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
    public class MeetingRoomServiceClient
    {
        private HttpClient CreateClient()
        {
            var meetingRoomServiceClient = new HttpClient() { BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceClient"]) };
            meetingRoomServiceClient.DefaultRequestHeaders.Accept.Clear();
            meetingRoomServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return meetingRoomServiceClient;
        }
        public List<MeetingRoomViewModel> GetMeetingRoomList()
        {
            List<MeetingRoomViewModel> meetingRoomList = new List<MeetingRoomViewModel>();
            HttpClient restClient = CreateClient();
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetAllMeetingRoom/");
            try
            {
                using (var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        meetingRoomList = JsonConvert.DeserializeObject<List<MeetingRoomViewModel>>(result);
                        return meetingRoomList;
                    }
                    else
                    {
                        return meetingRoomList;
                    }
                }
            }
            catch (Exception ex)
            {


            }
            return meetingRoomList;
        }
        public List<MeetingRoomViewModel> GetMeetingRoomById(MeetingRoomViewModel roomViewModel)
        {
            List<MeetingRoomViewModel> meetingRoomDetail = new List<MeetingRoomViewModel>();
            HttpClient restClient = CreateClient();
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetMeetingRoomById/" + roomViewModel.MeetingRoomId);
            try
            {
                using (var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        meetingRoomDetail = JsonConvert.DeserializeObject<List<MeetingRoomViewModel>>(result);
                        return meetingRoomDetail;
                    }
                    else
                    {
                        return meetingRoomDetail;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return meetingRoomDetail;
        }
        public MeetingRoomViewModel CreateMeetingRoom(MeetingRoomViewModel meetingRoomModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MeetingRoomViewModel, MeetingRoomDTO>();
            });
            IMapper mapper = config.CreateMapper();
            MeetingRoomViewModel responseMeetingRoom = new MeetingRoomViewModel();
            MeetingRoomDTO meetingRoomDetail = new MeetingRoomDTO();
            MeetingRoomRequest request = new MeetingRoomRequest();
            meetingRoomDetail = mapper.Map<MeetingRoomViewModel, MeetingRoomDTO>(meetingRoomModel);
            request.MeetingRoomDetail = meetingRoomDetail;
            HttpClient restClient = CreateClient();
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "CreateMeetingRoom/");
            try
            {
                using (var response = restClient.PostAsync(UriBuilder.Uri, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        responseMeetingRoom = JsonConvert.DeserializeObject<MeetingRoomViewModel>(result);
                        return responseMeetingRoom;
                    }
                    else
                    {
                        return responseMeetingRoom;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return responseMeetingRoom;
        }
    }
}