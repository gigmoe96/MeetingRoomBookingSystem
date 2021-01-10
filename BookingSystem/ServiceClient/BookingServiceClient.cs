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
using System.Globalization;

namespace BookingSystem.ServiceClient
{
    public class BookingServiceClient
    {
        private HttpClient CreateClient()
        {
            var staffServiceClient = new HttpClient() { BaseAddress = new Uri(ConfigurationManager.AppSettings["ServiceClient"]) };
            staffServiceClient.DefaultRequestHeaders.Accept.Clear();
            staffServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return staffServiceClient;
        }

        public List<BookingViewModel> GetBookingListByRoomId(BookingViewModel bookingModel)
        {
            List<BookingViewModel> bookingList = new List<BookingViewModel>();
            HttpClient restClient = CreateClient();
            //string bookingDate = string.Format("{0:s}", bookingModel.BookingDate);
            string bookingDate = bookingModel.BookingDate.ToString("yyyy-MM-dd");
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "GetBookingListByRoomId/" + bookingModel.MeetingRoomId + "/" + bookingDate);
            try
            {
                using (var response = restClient.GetAsync(UriBuilder.Uri).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        bookingList = JsonConvert.DeserializeObject<List<BookingViewModel>>(result);
                        return bookingList;
                    }
                    else
                    {
                        return bookingList;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return bookingList;
        }
        public BookingViewModel CreateBooking(BookingViewModel bookingModel)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingViewModel, BookingDTO>();
            });
            IMapper mapper = config.CreateMapper();
            BookingViewModel responseBooking = new BookingViewModel();
            BookingDTO bookingDetail = new BookingDTO();
            BookingRequest request = new BookingRequest();
            bookingDetail = mapper.Map<BookingViewModel, BookingDTO>(bookingModel);
            request.BookingDetail = bookingDetail;
            HttpClient restClient = CreateClient();
            var jsonObject = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var UriBuilder = new UriBuilder(restClient.BaseAddress + "CreateBooking/");
            try
            {
                using (var response = restClient.PostAsync(UriBuilder.Uri, content).GetAwaiter().GetResult())
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        responseBooking = JsonConvert.DeserializeObject<BookingViewModel>(result);
                        return responseBooking;
                    }
                    else
                    {
                        return responseBooking;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return responseBooking;
        }
    }
}