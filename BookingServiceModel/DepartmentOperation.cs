using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using BookingDomain.DTO;
using ServiceStack.ServiceInterface.ServiceModel;

namespace BookingServiceModel
{
    [DataContract]
    [Route("/GetAllDepartment/")]
    public class GetAllDepartmentRequest
    {
        [DataMember]
        public DepartmentDTO DepartmentList { get; set; }
    }
    [DataContract]
    [Route("/CreateDepartment/")]
    public class CreateDepartmentRequest
    {
        [DataMember]
        public DepartmentDTO DepartmentDetail { get; set; }
    }
    [DataContract]
    public class DepartmentResponse : IHasResponseStatus
    {
        [DataMember]
        public DepartmentDTO DepartmentDetail { get; set; }
        [DataMember]
        public ResponseStatus ResponseStatus { get; set; }
        public DepartmentResponse()
        {
            this.DepartmentDetail = DepartmentDetail;
            this.ResponseStatus = ResponseStatus;
        }
    }

}

    
    

