using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;

namespace BookingRepository.Abstract
{
    public interface IBookingRepository
    {
        bool SaveBooking(BookingDTO BookingModel);
        List<BookingDTO> GetTodayBookingListByRoomId(BookingDTO bookingDTO);
        List<BookingDTO> GetBookingListByRoomId(BookingDTO bookingDTO);
    }
}
