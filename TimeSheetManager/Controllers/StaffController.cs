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
    public class StaffController : ApiController
    {
        [Authorize]
        [HttpGet]
        public List<StaffModel> Get()
        {

            StaffData data = new StaffData();
            return data.GetStaffs();
        }

       

        public void Post(TimeSheetStaffDetailModel staffDetail)
        {
            StaffData data = new StaffData();
            data.SaveStaff(staffDetail);
        
        }

    }
}
