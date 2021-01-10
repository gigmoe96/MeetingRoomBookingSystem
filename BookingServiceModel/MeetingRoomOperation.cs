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
        [Route("/GetAllMeetingRoom/","GET")]
        public class GetAllMeetingRoomRequest
        {
            [DataMember]
            public MeetingRoomDTO MeetingRoomList { get; set; }
        }
        [DataContract]
        [Route("/GetMeetingRoomById/{MeetingRoomId}","GET")]
        public class GetMeetingRoomById
        {
            [DataMember]
            public string MeetingRoomId { get; set; }
        }

        [DataContract]
        [Route("/CreateMeetingRoom/","POST")]
        public class CreateMeetingRoomRequest
        {
            [DataMember]
            public MeetingRoomDTO MeetingRoomDetail { get; set; }
        }
        [DataContract]
        public class MeetingRoomResponse : IHasResponseStatus
        {
            [DataMember]
            public MeetingRoomDTO MeetingRoomDetail { get; set; }
            [DataMember]
            public ResponseStatus ResponseStatus { get; set; }
            public MeetingRoomResponse()
            {
                this.MeetingRoomDetail =MeetingRoomDetail;
                this.ResponseStatus = ResponseStatus;
            }
        }
       

    
}
