using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TimeSheetDesktopUI.EventModels;
using TimeSheetDesktopUI.Library.API;

namespace TimeSheetDesktopUI.ViewModels
{
    public class LoginViewModel:Screen
    {
        
        private string _userName= "hamuliya818@gmail.com";
        private string _password= "Pwd12345$";
        private readonly IAPIHelper _apiHelper;
        private readonly IEventAggregator _events;

        public LoginViewModel(IAPIHelper apiHelper,IEventAggregator events)
        {
            _apiHelper = apiHelper;
            _events = events;
        }
        public string UserName
        {
            get 
            { 
                
                return _userName;    
            }
            set 
            { 
                _userName = value;
                NotifyOfPropertyChange(() => UserName);
                NotifyOfPropertyChange(() => CanLogin);
            }
           
        }

        public bool IsErrorVisible
        {
            get
            {
                bool output = false;
                if (ErrorMessage?.Length > 0)
                {
                    output = true;
                }
                return output;
            }

        }

        public string Password
        {
            get { return _password; }
            set 
            { 
              _password=value;
              NotifyOfPropertyChange(() => Password);
              NotifyOfPropertyChange(() => CanLogin);
            }
            
        }


        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set 
            { 
                _errorMessage = value;
                NotifyOfPropertyChange(() => IsErrorVisible);
                NotifyOfPropertyChange(() => ErrorMessage);

            }
        }


        public bool CanLogin
        {
            get 
            {
                return !String.IsNullOrEmpty(_userName) && !String.IsNullOrEmpty(_password);  
            }
        }

        public async Task Login()
        {
            try
            {
                ErrorMessage = "";
                var result = await _apiHelper.Authenticate(UserName, Password);
                //Must be Access_Token, can not change to the other word.
                await _apiHelper.GetLoggedInUserInfo(result.Access_Token);
                await _events.PublishOnUIThreadAsync(new LogOnEvent());
            }
            catch (Exception ex)
            {
                ErrorMessage=ex.Message;
            }
        }


    }
}
