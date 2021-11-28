namespace ArlDrivingSchool.Core.DataTransferObject.Request
{
    public class UpdateBilling
    {
        public int BillingId { get; set; }
        public string TDCOnline { get; set; }
        public string TDCClassroom { get; set; }
        public string DEPOnline { get; set; }
        public string DEPClassroom { get; set; }
        public string PDCCarManual { get; set; }
        public string PDCCarMatic { get; set; }
        public string PDCCarCombination { get; set; }
        public string PDCMotorManual { get; set; }
        public string PDCMotorMatic { get; set; }
        public string PDCMotorCombination { get; set; }
        public string PDCTricycleManual { get; set; }
        public string PDCTricycleMatic { get; set; }
        public string PDCTricycleCombination { get; set; }
    }
}
