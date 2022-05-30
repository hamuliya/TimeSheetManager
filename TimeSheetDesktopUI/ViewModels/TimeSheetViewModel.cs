using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Library.API;
using TimeSheetDesktopUI.Models;

namespace TimeSheetDesktopUI.ViewModels
{
   public class TimeSheetViewModel:Screen, IHandle<WindowPopup>
    {
        private readonly TimeSheetStaffViewModel _staffview;
        private readonly TimeSheetPlantViewModel _plantview;
        private readonly TimeSheetMaterialViewModel _materialview;
        private readonly ClientInfoViewModel _clientview;
        private readonly IWindowManager _window;
        private IEventAggregator _events;

        [Obsolete]
        public TimeSheetViewModel(TimeSheetStaffViewModel staffview, TimeSheetPlantViewModel plantview,
            TimeSheetMaterialViewModel materialview,ClientInfoViewModel clientview, IWindowManager window, IStaffEndpoint staffEndpoint, IEventAggregator events)
        {
            _staffview = staffview;
            _plantview = plantview;
            _materialview = materialview;
            _clientview = clientview;
            _window = window;
            _events = events;
            _events.Subscribe(this);

        }

       

        public async void AddStaff()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartUpLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.CanResize;
            await _window.ShowWindowAsync(_staffview, null, settings);

        }

        public async void AddPlant()
        {

            dynamic settings = new ExpandoObject();
            settings.WindowsStartUpLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.CanResize;
            await _window.ShowWindowAsync(_plantview, null, settings);


        }


        public async void AddMaterial()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowsStartUpLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.CanResize;
            await _window.ShowWindowAsync(_materialview, null, settings);

        }

        public async void AddClient()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowsStartUpLocation=WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.CanResize;
            await _window.ShowWindowAsync(_clientview, null, settings);
        
        }

        public  void RemoveStaff()
        {
           Staffs.Remove(SelectedStaff);
        
        }


        public void RemovePlant()
        {
            Plants.Remove(SelectedPlant);

        }


        public void RemoveMaterial()
        { 
           Materials.Remove(SelectedMaterial);
        
        }
        public bool CanRemoveStaff
        { 
            get { return SelectedStaff != null;}
        }

        public bool CanRemovePlant
        {
            get { return SelectedPlant!= null; }
        }

        public bool CanRemoveMaterial
        {
            get { return SelectedMaterial != null; }
        }



        private TimeSheetPlantUseHoursDisplayModel _selectedPlant;

        public TimeSheetPlantUseHoursDisplayModel SelectedPlant
        {
            get { return _selectedPlant; }
            set { _selectedPlant = value;
                NotifyOfPropertyChange(() => CanRemovePlant);
            }
        }

        private TimeSheetStaffWorkHoursDisplayModel _selectedStaff;

        public TimeSheetStaffWorkHoursDisplayModel SelectedStaff
        {
            get { return _selectedStaff; }
            set { _selectedStaff = value;
                NotifyOfPropertyChange(() => CanRemoveStaff);
            }
        }


        private TimeSheetMaterialDisplayModel _selectedMaterial;

        public TimeSheetMaterialDisplayModel SelectedMaterial
        {
            get { return _selectedMaterial; }
            set { _selectedMaterial = value;
                NotifyOfPropertyChange(() => CanRemoveMaterial); 
            }
        }


        private void ActivateItemAsync(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }


    

        public Task HandleAsync(WindowPopup message, CancellationToken cancellationToken)
        {
           
                if (message.IsAdd == true)
                {
                    if (message.WindowName == "Staff")
                    {
                        Staffs = new BindingList<TimeSheetStaffWorkHoursDisplayModel>(_staffview.TimeSheetStaffWorkHoursDisplay);
                        NotifyOfPropertyChange(() => Staffs);
                    }
                    if (message.WindowName == "Plant")
                    {
                        Plants = new BindingList<TimeSheetPlantUseHoursDisplayModel>(_plantview.TimeSheetPlantUseHoursDisplay);
                        NotifyOfPropertyChange(() => Plants);
                    }
                    if (message.WindowName == "Material")
                    {
                        NotifyOfPropertyChange(() => Materials);
                        Materials = new BindingList<TimeSheetMaterialDisplayModel>(_materialview.TimeSheetMaterialDisplay);
                    }

                }
                message.IsAdd = false;
                message.WindowName = "";

             //?
                return null;

        }

        private BindingList<TimeSheetStaffWorkHoursDisplayModel> _staffs;
        public BindingList<TimeSheetStaffWorkHoursDisplayModel> Staffs
        {
            get { return _staffs; }
            set
            {
                _staffs = value;

                NotifyOfPropertyChange(() => Staffs);
            }
        }

        private BindingList<TimeSheetPlantUseHoursDisplayModel> _plants;

        public BindingList<TimeSheetPlantUseHoursDisplayModel> Plants
        {
            get { return _plants; }
            set
            {
                _plants = value;
                NotifyOfPropertyChange(() => Plants);
            }
        }

        private BindingList<TimeSheetMaterialDisplayModel> _materials;

        public BindingList<TimeSheetMaterialDisplayModel> Materials
        {
            get { return _materials; }
            set
            {
                _materials = value;
                NotifyOfPropertyChange(() => Materials);
            }
        }



        private DateTime _beginDate;

        public DateTime BeginDate
        {
            get { return _beginDate; }
            set
            {
                _beginDate = value;
                NotifyOfPropertyChange(() => BeginDate);
            }
        }

        private DateTime _endDate;

        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                NotifyOfPropertyChange(() => EndDate);
            }
        }

        private string _jobNo;

        public string JobNo
        {
            get { return _jobNo; }
            set
            {
                _jobNo = value;
                NotifyOfPropertyChange(() => JobNo);
            }
        }

        private string _client;

        public string Client
        {
            get { return _client; }
            set
            {
                _client = value;
                NotifyOfPropertyChange(() => Client);
            }
        }

        private string _description;


        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }



    }
}
