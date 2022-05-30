using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetDesktopUI.Models
{
    public class TimeSheetPlantUseHoursDisplayModel
    {
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string Description { get; set; }
        public float UseHours { get; set; }
    }
}


