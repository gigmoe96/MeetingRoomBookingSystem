using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain.DTO
{
    public class MeetingRoomDTO
        
    {
        public int MeetingRoomId { get; set; }
        public string MeetingRoomName { get; set; }
        
        public int RoomCapacity { get; set; }
       
        public bool Projector { get; set; }
        
        public bool Active {  get; set; }
    }
}
