using AutoMapper;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Library.API;
using TimeSheetDesktopUI.Models;

namespace TimeSheetDesktopUI.ViewModels
{
    public class TimeSheetPlantViewModel:Screen
    {
        private readonly IPlantEndpoint _plantEndpoint;
        private readonly IMapper _mapper;
        private readonly IEventAggregator _events;

        public List<TimeSheetPlantUseHoursDisplayModel> TimeSheetPlantUseHoursDisplay { get; set; }


        public void Add()
        { 
            TimeSheetPlantUseHoursDisplayModel timeSheetPlantUseHours= new TimeSheetPlantUseHoursDisplayModel();
            timeSheetPlantUseHours.PlantId = Plant.Id;
            timeSheetPlantUseHours.PlantName = Plant.PlantName;
            timeSheetPlantUseHours.Description = Description;
            timeSheetPlantUseHours.UseHours= UseHours;
            TimeSheetPlantUseHoursDisplay.Add(timeSheetPlantUseHours);
            _events.PublishOnUIThreadAsync(new WindowPopup
            {
                WindowName = "Plant",
                IsAdd = true
            }
            );
            Description = "";
            UseHours = 0;
            NotifyOfPropertyChange(()=>Description);
            NotifyOfPropertyChange(()=>UseHours);
        
        }



        public bool CanAdd
        {
            get 
            {
                bool output = false;

                if (!string.IsNullOrEmpty(Description) || UseHours > 0)
                { 
                  output = true; 
                }
                return output;
            
            }
        
        
        }

     



        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value;
                NotifyOfPropertyChange(() => CanAdd);
            
            }
        }


        private float _useHours;

        public float UseHours
        {
            get { return _useHours; }
            set { _useHours = value;
                NotifyOfPropertyChange(() => CanAdd);
            }
        }


        public void Close()
        {
            TryCloseAsync();
        }

        public TimeSheetPlantViewModel(IPlantEndpoint plantEndpoint,IMapper mapper,IEventAggregator events)
        {
            _plantEndpoint = plantEndpoint;
            _mapper = mapper;
            _events = events;
            TimeSheetPlantUseHoursDisplay = new List<TimeSheetPlantUseHoursDisplayModel>();
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            try 
            {
                await LoadPlants();

            }
            catch(Exception ex)
            {  
               Console.WriteLine(ex.Message);
            }
        }
        private async Task LoadPlants()
        {
            var plantlist = await _plantEndpoint.GetAll();
            var  plants=_mapper.Map<List<PlantComboxModel>>(plantlist);
            IList<PlantComboxModel> list = new List<PlantComboxModel>();
            foreach (var plant in plants)
            {
                Plant = plant;
                list.Add(plant);
            }
            Plants= new CollectionView(list);
            NotifyOfPropertyChange(() => Plants);
        
        }


        private PlantComboxModel _plant;

        public PlantComboxModel Plant
        {
            get { return _plant; }
            set { _plant = value; }
        }


        private CollectionView _plants;

        public CollectionView Plants
        {
            get { return _plants; }
            set { _plants = value; }
        }

    }
}
