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
    public class MeetingRoomService:Service
    {
        private IMeetingRoomRepository meetingRoomRepository;
        public MeetingRoomService(IMeetingRoomRepository repository)
        {
            meetingRoomRepository = repository;
        }
        public List<MeetingRoomDTO> GET(GetAllMeetingRoomRequest request)
        {
            List<MeetingRoomDTO> meetingRoomList = new List<MeetingRoomDTO>();
            meetingRoomList = meetingRoomRepository.GetAllMeetingRoom();
            return meetingRoomList;
        }
        public List<MeetingRoomDTO> GET(GetMeetingRoomById request)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GetMeetingRoomById, MeetingRoomDTO>();
            });
            MeetingRoomDTO MeetingRoomInfo = new MeetingRoomDTO();
            List<MeetingRoomDTO> MeetingRoomDetail = new List<MeetingRoomDTO>();
            IMapper mapper = config.CreateMapper();
            MeetingRoomInfo = mapper.Map<GetMeetingRoomById, MeetingRoomDTO>(request);
            MeetingRoomDetail = meetingRoomRepository.GetMeetingRoomById(MeetingRoomInfo);
            return MeetingRoomDetail;
        }
        public MeetingRoomResponse POST(CreateMeetingRoomRequest request)
        {
            MeetingRoomResponse response = new MeetingRoomResponse();
            MeetingRoomDTO meetingRoomDetail = new MeetingRoomDTO();
            meetingRoomDetail = request.MeetingRoomDetail;
            bool isSuccess = false;
            isSuccess = meetingRoomRepository.SaveMeetingRoom(meetingRoomDetail);
            if (isSuccess)
            {
                response.MeetingRoomDetail = request.MeetingRoomDetail;
            }
            else
            {

            }
            return response;
        }
    }
}
