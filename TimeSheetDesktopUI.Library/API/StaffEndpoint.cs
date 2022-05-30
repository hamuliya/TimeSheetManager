using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TimeSheetDesktopUI.Library.Models;

namespace TimeSheetDesktopUI.Library.API
{
    public class StaffEndpoint : IStaffEndpoint
    {

        private IAPIHelper _apiHelper;

        public StaffEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<StaffModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.APIClient.GetAsync("/api/Staff"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<StaffModel>>();
                    return result;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }


        }


    }
}
