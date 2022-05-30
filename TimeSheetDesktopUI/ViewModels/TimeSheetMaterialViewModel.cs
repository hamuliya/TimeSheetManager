using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Models;

namespace TimeSheetDesktopUI.ViewModels
{
    public class TimeSheetMaterialViewModel:Screen
    {
        private readonly IEventAggregator _events;
        public List<TimeSheetMaterialDisplayModel> TimeSheetMaterialDisplay { get; set; }
        public TimeSheetMaterialViewModel(IEventAggregator events)
        {
            TimeSheetMaterialDisplay = new List<TimeSheetMaterialDisplayModel>();
            _events = events;
        }
        public void Close()
        { 
           TryCloseAsync();
        
        }

        public void Add()
        { 
            TimeSheetMaterialDisplayModel timeSheetMaterialDisplay=new TimeSheetMaterialDisplayModel();
            timeSheetMaterialDisplay.MaterialIn = MaterialIn;
            timeSheetMaterialDisplay.MaterialOut = MaterialOut;
            TimeSheetMaterialDisplay.Add(timeSheetMaterialDisplay);
            _events.PublishOnUIThreadAsync(new WindowPopup
            {
                WindowName = "Material",
                IsAdd = true,
            });
     
        }

        private string _materialIn;

        public string MaterialIn
        {
            get { return _materialIn; }
            set { _materialIn = value; }
        }

        private string _materialOut;
      

        public string MaterialOut
        {
            get { return _materialOut; }
            set { _materialOut = value; }
        }




    }
}
