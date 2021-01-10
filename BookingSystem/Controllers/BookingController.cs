using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingSystem.ServiceClient;
using BookingSystem.ViewModel;

namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private MeetingRoomServiceClient _meetingRoomServiceClient;
        private BookingServiceClient _bookingServiceClient;
        public StaffLogInViewModel staffLogInViewModel = new StaffLogInViewModel();
        public BookingController()
        {
            _meetingRoomServiceClient = new MeetingRoomServiceClient();
            _bookingServiceClient = new BookingServiceClient();
        }
        public ActionResult BookRoom(int StaffId)
        {
           
            List<MeetingRoomViewModel> meetingRoomModelList = new List<MeetingRoomViewModel>();
            meetingRoomModelList = _meetingRoomServiceClient.GetMeetingRoomList();
            ViewBag.StaffId = StaffId;
            return View(meetingRoomModelList);
        }
        public ActionResult BookingDetail(string BookingDate,string meetingRoomId,string staffId,string ErrorMessage="")
        {
          
            MeetingRoomViewModel model = new MeetingRoomViewModel();
            model.MeetingRoomId = int.Parse(meetingRoomId);
            int logInStaffId = int.Parse(staffId);
            ViewBag.StaffId = logInStaffId;
            model.ErrorMessage = ErrorMessage;
            CultureInfo culture = new CultureInfo("en-US");
            DateTime Date = Convert.ToDateTime(BookingDate, culture);
            ViewBag.BookingDate = Date;
            List<MeetingRoomViewModel> meetingRoomDetail = new List<MeetingRoomViewModel>();
            MeetingRoomViewModel meetingRoom = new MeetingRoomViewModel();
     
            meetingRoomDetail = _meetingRoomServiceClient.GetMeetingRoomById(model);
            foreach(var item in meetingRoomDetail)
            {
                meetingRoom = item;
            }
            meetingRoom.BookingDate = ViewBag.BookingDate;
            meetingRoom.StaffId = ViewBag.StaffId;
            return View("BookingDetail",meetingRoom);
        }
        public PartialViewResult _AddBooking(int meetingRoomId, DateTime? BookingDate,int StaffId)
        {
            ViewBag.BookingDate = BookingDate;
            ViewBag.meetingRoomId = meetingRoomId;
            ViewBag.staffId = StaffId;
            return PartialView();
        }
        public PartialViewResult _BookingSummary(int meetingRoomId,DateTime bookingDate)
        {
            List<BookingViewModel> bookingList = new List<BookingViewModel>();
            BookingViewModel booking = new BookingViewModel();
            booking.MeetingRoomId = meetingRoomId;
            booking.BookingDate = bookingDate;
            bookingList = _bookingServiceClient.GetBookingListByRoomId(booking);
            return PartialView("_BookingSummary",bookingList);
        }
        public PartialViewResult _EditBooking(int BookingId)
        {
            return PartialView();
        }
        //[HttpPost]
        //public ActionResult CreateBooking(BookingViewModel bookingModel)
        //{
        //    MeetingRoomViewModel meetingViewModel = new MeetingRoomViewModel();
        //    if (ModelState.IsValid)
        //    {
                
        //        if (bookingModel.StartTime > DateTime.Now)
        //        {
        //            if (bookingModel.EndTime > bookingModel.StartTime)
        //            {
        //                List<BookingViewModel> bookingList = new List<BookingViewModel>();
        //                bookingList = _bookingServiceClient.GetBookingListByRoomId(bookingModel);
        //                int listCount = bookingList.Count();
        //                for (int i = 0; i < listCount; i++)
        //                {
        //                    if (bookingList[i].StartTime <= bookingModel.StartTime && bookingList[i].StartTime >= bookingModel.EndTime)
        //                    {
        //                        ModelState.AddModelError("StartTime", "This time slot is already booked!");
        //                    }
        //                    else if (bookingList[i].StartTime <= bookingModel.EndTime && bookingList[i].StartTime >= bookingModel.StartTime)
        //                    {
        //                        ModelState.AddModelError("EndTime", "This time slot is already booked!");
        //                    }
        //                    else
        //                    {
        //                        BookingViewModel bookingDetail = new BookingViewModel();
        //                        bookingDetail = _bookingServiceClient.CreateBooking(bookingModel);
        //                        if (bookingDetail.BookingDate != null)
        //                        {
        //                            return RedirectToAction("BookingDetail", new { BookingDate = bookingModel.BookingDate, meetingRoomId = bookingModel.MeetingRoomId, staffId = bookingModel.StaffId });
        //                        }
        //                    }
        //                }

        //            }
        //            else
        //            {
        //                meetingViewModel.ErrorMessage = "Booking End Time must not be earlier than Start Time";
        //            }

        //        }
        //        else
        //        {
        //            meetingViewModel.ErrorMessage = "Booking Time cannot be earlier than current time";
        //        }


        //    }
        //    return RedirectToAction("BookingDetail", new { BookingDate =bookingModel.BookingDate, meetingRoomId = bookingModel.MeetingRoomId ,staffId=bookingModel.StaffId,errorMessage=meetingViewModel.ErrorMessage});
        //}
        public JsonResult CreateBooking(BookingViewModel bookingModel)
        {
            bool success = false;
            string message = null;
            List<BookingViewModel> bookingList = new List<BookingViewModel>();
            bookingList = _bookingServiceClient.GetBookingListByRoomId(bookingModel);
            int listCount = bookingList.Count();
            if (listCount == 0)
            {
                BookingViewModel bookingDetail = new BookingViewModel();
                bookingDetail = _bookingServiceClient.CreateBooking(bookingModel);
                if (bookingDetail.BookingDate != null)
                {
                    success = true;
                    message = "Booking Succeesful!";

                }
            }
            else
            {
                for (int i = 0; i < listCount; i++)
                {
                    if (bookingList[i].StartTime < bookingModel.StartTime && bookingList[i].EndTime > bookingModel.StartTime)
                    {
                        success = false;
                        message = "The Time slot is already Booked!";
                    }
                    else if (bookingList[i].StartTime < bookingModel.EndTime && bookingList[i].EndTime > bookingModel.EndTime)
                    {
                        success = false;
                        message = "The Time slot is already Booked!";
                    }
                    else
                    {
                        BookingViewModel bookingDetail = new BookingViewModel();
                        bookingDetail = _bookingServiceClient.CreateBooking(bookingModel);
                        if (bookingDetail.BookingDate != null)
                        {
                            success = true;
                            message = "Booking Succeesful!";

                        }

                    }
                }
            }
          
            return this.Json(new
            {
                success,
                message,
            });
        }

    }
}