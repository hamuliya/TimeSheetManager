using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetDesktopUI.Library.Models;
using System.Net.Http;

namespace TimeSheetDesktopUI.Library.API
{
    public class PlantEndpoint : IPlantEndpoint
    {
      
        private IAPIHelper _apiHelper;

        public PlantEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<PlantModel>> GetAll()
        {

            using (HttpResponseMessage response = await _apiHelper.APIClient.GetAsync("/api/Plant"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<PlantModel>>();
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
