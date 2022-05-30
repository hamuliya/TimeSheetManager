using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetDesktopUI.Library.Models;

namespace TimeSheetDesktopUI.Library.API
{
    public interface IPlantEndpoint
    {
        Task<List<PlantModel>> GetAll();
    }
}