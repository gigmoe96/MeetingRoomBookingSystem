using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;

namespace BookingRepository.Abstract
{
    public interface IMeetingRoomRepository
    {
        bool SaveMeetingRoom(MeetingRoomDTO meetingRoom);
        List<MeetingRoomDTO> GetAllMeetingRoom();
        List<MeetingRoomDTO> GetMeetingRoomById(MeetingRoomDTO meetingRoomInfo);
    }
}
