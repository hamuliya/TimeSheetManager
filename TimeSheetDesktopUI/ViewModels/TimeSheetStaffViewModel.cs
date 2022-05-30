using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Library.API;
using TimeSheetDesktopUI.Library.Models;
using TimeSheetDesktopUI.Models;
using TimeSheetDesktopUI.Views;


namespace TimeSheetDesktopUI.ViewModels
{
    public class TimeSheetStaffViewModel:Screen
    {
        private readonly IStaffEndpoint _staffEndpoint;
        private IMapper _mapper;
       
      
        private readonly IEventAggregator _events;

        public List<TimeSheetStaffWorkHoursDisplayModel> TimeSheetStaffWorkHoursDisplay { get; set; }

        public TimeSheetStaffViewModel(IStaffEndpoint staffEndpoint, IMapper mapper, IEventAggregator events)
        {
            _staffEndpoint = staffEndpoint;
            _mapper = mapper;
           
           
            _events = events;
            TimeSheetStaffWorkHoursDisplay = new List<TimeSheetStaffWorkHoursDisplayModel>();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try
            {
                await LoadStaffs();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task LoadStaffs()

        {
            var staffList = await _staffEndpoint.GetAll();
            var staffs = _mapper.Map<List<StaffComboxModel>>(staffList);

            IList<StaffComboxModel> list = new List<StaffComboxModel>();
            foreach (var staff in staffs)
            {

                Staff = staff;
                list.Add(staff);

            }
            Staffs = new CollectionView(list);
            NotifyOfPropertyChange(() => Staffs);

        }


        public void Add()
        {

            TimeSheetStaffWorkHoursDisplayModel timeSheetStaffWorkHours = new TimeSheetStaffWorkHoursDisplayModel();
            timeSheetStaffWorkHours.StaffId = Staff.Id;
            timeSheetStaffWorkHours.StaffName = Staff.StaffName;
            timeSheetStaffWorkHours.TotalHours = TotalHours;
            timeSheetStaffWorkHours.LabourHours = LabourHours;
            TimeSheetStaffWorkHoursDisplay.Add(timeSheetStaffWorkHours);

            _events.PublishOnUIThreadAsync(new WindowPopup
            {
                WindowName = "Staff",
                IsAdd = true
            });


            TotalHours = 0;
            LabourHours = 0;
            NotifyOfPropertyChange(() => TotalHours);
            NotifyOfPropertyChange(() => LabourHours);

        }

        public bool CanAdd
        {
            get
            {
                bool output = false;

                if (TotalHours > 0 || LabourHours > 0)
                {
                    output = true;
                }
                return output;    
            
            }
        
        }


       




        public void Close()
        {

            //_events.PublishOnUIThreadAsync(new WindowPopup
            //{
            //    WindowName = "Staff",
            //    IsClosed = true
            //});
            TryCloseAsync();
        }






        private StaffComboxModel _staff;

        public StaffComboxModel Staff
        {
            get { return _staff; }
            set { _staff = value; }
        }



        private CollectionView _staffs;

        public CollectionView Staffs
        {
            get { return _staffs; }
            set { _staffs = value; }
        }




        private float _totalHours;

        public float TotalHours
        {
            get { return _totalHours; }
            set { _totalHours = value;
                NotifyOfPropertyChange(() => CanAdd);
            }
        }


        private float _labourHours;


        public float LabourHours
        {
            get { return _labourHours; }
            set { _labourHours = value;
                 NotifyOfPropertyChange(() => CanAdd);
            }
        }


    }
}
