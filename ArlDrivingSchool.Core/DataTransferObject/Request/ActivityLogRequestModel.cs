namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class ActivityLogRequestModel
    {
        public int ActivityLogTypeId { get; set; }
        public int UserId { get; set; }
        public string StudentFullName { get; set; }
        public string PageName { get; set; }
    }
}
