using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.Library.Internal.DataAccess;
using TimeSheetManager.Library.Models;

namespace TimeSheetManager.Library.DataAccess
{
    public class PlantData
    {
        public List<PlantModel> GetPlants()
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<PlantModel, dynamic>("dbo.spAllPlants", new { }, "TimeSheetDB"); 
        
        }
    }
}


