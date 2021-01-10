using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;
using AutoMapper;
using BookingDomain;
using BookingRepository.Abstract;
using System.Data.SqlClient;

namespace BookingRepository.Concrete
{
    public class BookingsRepository:IBookingRepository
    {
        private EFDbContext _dbcontext = new EFDbContext();
        public bool SaveBooking(BookingDTO bookingModel)
        {
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<BookingDTO, Booking>();
              });
            IMapper mapper = config.CreateMapper();
            Booking booking = new Booking();
            booking = mapper.Map<BookingDTO, Booking>(bookingModel);
            int resultCount = 0;
            try
            {
                _dbcontext.Bookings.Add(booking);
                resultCount = _dbcontext.SaveChanges();
            }
            catch(Exception e)
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
        public List<BookingDTO>GetTodayBookingListByRoomId(BookingDTO bookingDTO)
        {
            List<Booking> booking = new List<Booking>();
            List<BookingDTO> bookingDto = new List<BookingDTO>();
            booking = _dbcontext.Database.SqlQuery<Booking>(@"EXEC GetTodayBookingListByRoomId @MeetingRoomId",
            new SqlParameter("MeetingRoomId",bookingDTO.MeetingRoomId)).ToList<Booking>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Booking, BookingDTO>();
            });
            IMapper mapper = config.CreateMapper();
            bookingDto = booking.Select(x => mapper.Map<BookingDTO>(x)).ToList();
            return bookingDto;
        }
        public List<BookingDTO>GetBookingListByRoomId(BookingDTO bookingDTO)
        {
            List<Booking> booking = new List<Booking>();
            List<BookingDTO> bookingDto = new List<BookingDTO>();
            booking = _dbcontext.Database.SqlQuery<Booking>(@"EXEC GetBookingListByMeetingRoomId @MeetingRoomId,@BookingDate",
                new SqlParameter("MeetingRoomId", bookingDTO.MeetingRoomId),
                new SqlParameter("BookingDate",bookingDTO.BookingDate)).ToList<Booking>();
            var config = new MapperConfiguration(cfg =>
              {
                  cfg.CreateMap<Booking, BookingDTO>();
              });
            IMapper mapper = config.CreateMapper();
            bookingDto = booking.Select(x => mapper.Map<BookingDTO>(x)).ToList();
            return bookingDto;
        }
    }
}
