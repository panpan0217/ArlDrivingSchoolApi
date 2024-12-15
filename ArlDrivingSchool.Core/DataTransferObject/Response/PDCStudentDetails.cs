using ArlDrivingSchool.Core.Models.Payments;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class PDCStudentDetails
    {
        public virtual PDCStudentWithStatus PDCStudentWithStatus { get; set; }
        public virtual PDCPayment PDCPayment { get; set; }

    }
}
