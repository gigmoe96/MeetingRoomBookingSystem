using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSystem.ServiceClient;
using BookingSystem.ViewModel;

namespace BookingSystem.Controllers
{
    public class MeetingRoomController : Controller
    {
        private MeetingRoomServiceClient _meetingRoomServiceClient;
        public MeetingRoomController()
        {
            _meetingRoomServiceClient = new MeetingRoomServiceClient();
        }

        public ActionResult MeetingRooms()
        {
            return View();
        }
        public PartialViewResult _MeetingRoomListing()
        {
            List<MeetingRoomViewModel> meetingRoomModelList = new List<MeetingRoomViewModel>();
            meetingRoomModelList = _meetingRoomServiceClient.GetMeetingRoomList();
            return PartialView(meetingRoomModelList);
        }
        public PartialViewResult _CreateMeetingRoom()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult CreateMeetingRoom(MeetingRoomViewModel meetingRoomModel)
        {
            if (ModelState.IsValid)
            {
                MeetingRoomViewModel meetingRoomDetail = new MeetingRoomViewModel();
                meetingRoomDetail = _meetingRoomServiceClient.CreateMeetingRoom(meetingRoomModel);
                if (meetingRoomDetail.MeetingRoomName != null)
                {
                    return RedirectToAction("MeetingRooms", "MeetingRoom");
                }
            }
            return View("MeetingRooms");
        }
    }
}