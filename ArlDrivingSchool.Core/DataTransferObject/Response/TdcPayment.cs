using ArlDrivingSchool.Core.Models.Payments;

namespace ArlDrivingSchool.Core.DataTransferObject.Response
{
    public class TdcPayment
    {
        public virtual StudentWithStatus StudentWithStatus { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
