using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ServiceStack.ServiceHost;
using BookingDomain.DTO;
using ServiceStack.ServiceInterface.ServiceModel;

namespace BookingServiceModel
{
   [DataContract]
   [Route("/GetAllStaff/","GET")]
   public class GetAllStaffRequest
    {
        [DataMember]
        public StaffDTO StaffList { get; set; }
    }
   [DataContract]
   [Route("/CreateStaff/","POST")]
   public class CreateStaffRequest
    {
        [DataMember]
        public StaffDTO StaffDetail { get; set; }
    }
    [DataContract]
    public class StaffResponse : IHasResponseStatus
    {
        [DataMember]
        public StaffDTO StaffDetail { get; set; }
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
        public StaffResponse()
        {
            this.StaffDetail = StaffDetail;
            this.ResponseStatus = ResponseStatus;
        }
    }
    [DataContract]
    [Route("/GetStaffByCredential/{UserName}/{Password}","GET")]
    public class GetStaffByCredentialRequest
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }
    }
}
