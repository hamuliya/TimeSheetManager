using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetDesktopUI.Models
{
    public class TimeSheetStaffWorkHoursDisplayModel
    {
       
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public float TotalHours { get; set; }
        public float LabourHours { get; set; }
    }
}


