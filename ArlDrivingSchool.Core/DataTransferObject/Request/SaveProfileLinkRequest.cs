namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class SaveProfileLinkRequest
    {
        public int UserId { get; set; }
        public string ProfileLink { get; set; }
    }
}
