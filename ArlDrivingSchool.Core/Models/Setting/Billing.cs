using System;
using System.Collections.Generic;
using System.Text;

namespace ArlDrivingSchool.Core.Models.Setting
{
    public class Billing
    {
        public int BillingId { get; set; }
        public int TDCOnline { get; set; }
        public int TDCClassroom { get; set; }
        public int DEPOnline { get; set; }
        public int DEPClassroom { get; set; }
        public int PDCCarManual { get; set; }
        public int PDCCarMatic { get; set; }
        public int PDCCarCombination { get; set; }
        public int PDCMotorManual { get; set; }
        public int PDCMotorMatic { get; set; }
        public int PDCMotorCombination { get; set; }
        public int PDCTricycleManual { get; set; }
        public int PDCTricycleMatic { get; set; }
        public int PDCTricycleCombination { get; set; }
    }
}
