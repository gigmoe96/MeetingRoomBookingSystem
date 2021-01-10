using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;
using ServiceStack.ServiceInterface.ServiceModel;

namespace BookingServiceModel
{
    [DataContract]
    [Route("/CreateBooking/","POST")]
    public class CreateBookingRequest
    {
        [DataMember]
        public BookingDTO BookingDetail { get; set; }

    }
    [DataContract]
    [Route("/GetBookingListByRoomId/{MeetingRoomId}/{BookingDate}","GET")]
    public class GetBookingListByRoomIdRequest
    {
        [DataMember]
        public int MeetingRoomId { get; set; }
        [DataMember]
        public DateTime BookingDate { get; set; }
    }
    [DataContract]
    public class BookingResponse : IHasResponseStatus
    {
        [DataMember]
        public BookingDTO BookingDetail { get; set; }
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
        public BookingResponse()
        {
            this.BookingDetail = BookingDetail;
            this.ResponseStatus = ResponseStatus;
        }
    }
}
