using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.ViewModel
{
    public class MeetingRoomViewModel
    {
        public int MeetingRoomId { get; set; }
        [Display(Name = "MeetingRoom Name")]
        public string MeetingRoomName { get; set; }
        [Display(Name = "Room Capacity")]
        public int RoomCapacity { get; set; }
        [Display(Name = "Projector")]
        public bool Projector { get; set; }
        [Display(Name = "Active")]
        public bool Active { get; set; }
        [Display(Name = "BookingDate")]
        public DateTime BookingDate { get; set; }
        [Display(Name ="Staff Id")]
        public int StaffId { get; set; }
        public string ErrorMessage { get; set; }
      
    }
}