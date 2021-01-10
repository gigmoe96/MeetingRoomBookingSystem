using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using BookingServiceInterface;
using ServiceStack.WebHost.Endpoints;
using Funq;
using BookingRepository.Abstract;
using BookingRepository.Concrete;


namespace BookingService
{
    public class AppHost : AppHostBase
    {
        public AppHost():base("Booking Services", typeof(StaffService).Assembly)
        {

        }

        public override void Configure(Container container)
        {
            container.Register<IStaffRepository>(c => new StaffRepository());
            container.Register<IDepartmentRepository>(c => new DepartmentRepository());
            container.Register<IMeetingRoomRepository>(c => new MeetingRoomRepository());
            container.Register<IBookingRepository>(c => new BookingsRepository());
        }
    }
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            new AppHost().Init();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}