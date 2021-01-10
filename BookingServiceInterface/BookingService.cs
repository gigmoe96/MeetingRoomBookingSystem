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
    public class BookingService:Service
    {
        private IBookingRepository bookingRepository;
        public BookingService(IBookingRepository repository)
        {
            bookingRepository = repository;
        }
        public List<BookingDTO> GET(GetBookingListByRoomIdRequest request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetBookingListByRoomIdRequest, BookingDTO>();
            });
            BookingDTO bookingDTO = new BookingDTO();
            List<BookingDTO> bookingList = new List<BookingDTO>();
            IMapper mapper = config.CreateMapper();
            bookingDTO = mapper.Map<GetBookingListByRoomIdRequest, BookingDTO>(request);
            if (bookingDTO.BookingDate == DateTime.Today)
            {
                bookingList = bookingRepository.GetTodayBookingListByRoomId(bookingDTO);
            }
            else
            {
                bookingList = bookingRepository.GetBookingListByRoomId(bookingDTO);
            }
            
            return bookingList;
        }
        public BookingResponse POST(CreateBookingRequest request)
        {
            BookingResponse response = new BookingResponse();
            BookingDTO bookingDetail = new BookingDTO();
            bookingDetail = request.BookingDetail;
            bool isSuccess = false;
            isSuccess = bookingRepository.SaveBooking(bookingDetail);
            if (isSuccess)
            {
                response.BookingDetail = request.BookingDetail;
            }
            else
            {

                response.BookingDetail = null;
            }
            return response;
        }
    }
}
