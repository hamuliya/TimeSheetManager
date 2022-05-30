﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using Caliburn.Micro;
using TimeSheetDesktopUI.Library.API;
using TimeSheetDesktopUI.Library.Models;
using TimeSheetDesktopUI.Models;
using TimeSheetDesktopUI.ViewModels;

namespace TimeSheetDesktopUI
{
    public class Bootstrapper:BootstrapperBase
    {
       private readonly SimpleContainer _container=new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }


        private IMapper ConfigureAutomapper()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffModel, StaffComboxModel>();
                cfg.CreateMap<PlantModel, PlantComboxModel>();
               
            });

            var output = config.CreateMapper();
            return output;

        }

        protected override void Configure()
        {
            _container.Instance(ConfigureAutomapper());

            //when you ask certain instance, it will return to you.
            _container.Instance(_container)
                .PerRequest<IStaffEndpoint, StaffEndpoint>()
                .PerRequest<IPlantEndpoint, PlantEndpoint>();


            _container
                .Singleton<IAPIHelper, APIHelper>()
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<ILoggedInUserModel, LoggedInUserModel>();
                
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType,viewModelType.ToString(),viewModelType));

         

        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }
        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance); 
        }

    }
}
