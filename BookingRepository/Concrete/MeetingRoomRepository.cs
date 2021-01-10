using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingRepository.Abstract;
using BookingDomain.DTO;
using BookingDomain;
using AutoMapper;
using System.Data.SqlClient;

namespace BookingRepository.Concrete
{
   public class MeetingRoomRepository:IMeetingRoomRepository
    {
        private EFDbContext _dbContext = new EFDbContext();
        public bool SaveMeetingRoom(MeetingRoomDTO meetingRoomDetail)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MeetingRoomDTO, MeetingRoom>();
            });
            IMapper mapper = config.CreateMapper();
            MeetingRoom meetingRoom = new MeetingRoom();
            meetingRoom = mapper.Map<MeetingRoomDTO, MeetingRoom>(meetingRoomDetail);
            int resultCount = 0;
            try
            {
                _dbContext.MeetingRooms.Add(meetingRoom);
                resultCount = _dbContext.SaveChanges();
            }
            catch (Exception ex)
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
        public List<MeetingRoomDTO> GetAllMeetingRoom()
        {
            List<MeetingRoom> meetingRoomList = _dbContext.Database.SqlQuery<MeetingRoom>(@"EXEC GetAllMeetingRoom").ToList<MeetingRoom>();
            List<MeetingRoomDTO> meetingRoomDTO = new List<MeetingRoomDTO>();
            var config = new MapperConfiguration(cfg =>
            {
               cfg.CreateMap<MeetingRoom, MeetingRoomDTO>();
            });
            IMapper mapper = config.CreateMapper();
            meetingRoomDTO = meetingRoomList.Select(x => mapper.Map<MeetingRoomDTO>(x)).ToList();
            return meetingRoomDTO;
        }
        public List<MeetingRoomDTO> GetMeetingRoomById(MeetingRoomDTO meetingRoomInfo)
        {
            List<MeetingRoom> meetingRoom = new List<MeetingRoom>();
            List<MeetingRoomDTO> response = new List<MeetingRoomDTO>();
            meetingRoom = _dbContext.Database.SqlQuery<MeetingRoom>(@"EXEC GetMeetingRoomById @Id",
            new SqlParameter("Id", meetingRoomInfo.MeetingRoomId)).ToList<MeetingRoom>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<MeetingRoom, MeetingRoomDTO>();
            });
            IMapper mapper = config.CreateMapper();
            response = meetingRoom.Select(x => mapper.Map<MeetingRoomDTO>(x)).ToList();
            return response;
        }
    }
}
