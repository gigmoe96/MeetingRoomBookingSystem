using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDomain.DTO
{
    public class BookingDTO
    {
        public DateTime BookingDate { get; set; }
       
        public DateTime StartTime { get; set; }
        
        public DateTime EndTime { get; set; }
       
        public bool Extended { get; set; }
        
        public DateTime ExtendedTime { get; set; }
       
        public int Attendees { get; set; }
        public string MeetingDescription { get; set; }
        
        public int StaffId { get; set; }
       
        public int MeetingRoomId { get; set; }
        
    }
}
