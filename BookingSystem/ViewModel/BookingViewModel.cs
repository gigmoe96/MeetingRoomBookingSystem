using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.ViewModel
{
    public class BookingViewModel
    {
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }
   
        [Display(Name = "From")]
        public DateTime StartTime { get; set; }
        
        [Display(Name = "To")]
        public DateTime EndTime { get; set; }
        
        [Display(Name = "Extended")]
        public bool Extended { get; set; }
      
        [Display(Name = "Extended To")]
        public DateTime ExtendedTime { get; set; }
        
        [Display(Name = "Attendees")]
        public int Attendees { get; set; }
        [Display(Name ="Description")]
        public string MeetingDescription { get; set; }
        [Display(Name ="Staff Id")]
        public int StaffId { get; set; }
       [Display(Name ="MeetingRoom Id")]
       public int MeetingRoomId { get; set; }
    }
}
