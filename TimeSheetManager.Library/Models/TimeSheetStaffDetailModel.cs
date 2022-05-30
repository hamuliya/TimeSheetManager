using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetManager.Library.Models
{
    public class TimeSheetStaffDetailModel
    {
        public int Id { get; set; }
        public int TimeSheetId { get; set; }
        public int StaffId { get; set; }
        public float TotalHours { get; set; }
        public float LabourHours { get; set; }
    }
}

  