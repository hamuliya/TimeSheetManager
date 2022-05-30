using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeSheetManager.Library.DataAccess;
using TimeSheetManager.Library.Models;

namespace TimeSheetManager.Controllers
{
    public class PlantController : ApiController
    {
        public List<PlantModel> Get()
        { 
          PlantData data=new PlantData();
          return  data.GetPlants();       
        }

    }
}
