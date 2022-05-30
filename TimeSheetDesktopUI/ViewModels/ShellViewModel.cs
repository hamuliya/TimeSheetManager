using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Library.API;
using TimeSheetDesktopUI.Library.Models;

namespace TimeSheetDesktopUI.ViewModels
{
    public class ShellViewModel:Conductor<object>, IHandle<LogOnEvent>
    {

        private readonly IEventAggregator _events;
        private readonly IAPIHelper _apiHelper;
        private readonly ILoggedInUserModel _user;
        private readonly TimeSheetViewModel _timesheetVM;

        [Obsolete]
        public ShellViewModel(IEventAggregator events,IAPIHelper apiHelper,ILoggedInUserModel user,TimeSheetViewModel timeSheetVM)
        {
            _events = events;
            _apiHelper = apiHelper;
            _user = user;
            _timesheetVM = timeSheetVM;
            _events.Subscribe(this);
            ActivateItemAsync(IoC.Get<LoginViewModel>());
        }


       

        public bool IsLoggedIn
        {
            get 
            {
                bool output = false;

                if (!string.IsNullOrEmpty(_user.Token))
                { 
                  output = true;
                }
                return output; 
            
            }
            
        }

        public Task HandleAsync(LogOnEvent message, CancellationToken cancellationToken)
        {
            NotifyOfPropertyChange(() => IsLoggedIn);
            return ActivateItemAsync(_timesheetVM);



        }
    }
}
