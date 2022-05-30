using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.Library.Internal.DataAccess;
using TimeSheetManager.Library.Models;

namespace TimeSheetManager.Library.DataAccess
{
    public class StaffData
    {

   
        public List<StaffModel> GetStaffs()
        { 
           SqlDataAccess sql=new SqlDataAccess();
           return sql.LoadData<StaffModel, dynamic>("dbo.spAllStaffs", new { }, "TimeSheetDB");     
        
        }

        public void SaveStaff(TimeSheetStaffDetailModel staffDetail)
        {
            SqlDataAccess sql = new SqlDataAccess();
            {
                try
                {

                    sql.SaveData<TimeSheetStaffDetailModel>("dbo.spTimeSheet_StaffWorkHours_Insert", staffDetail, "TimeSheetDB");
                }
                catch (Exception ex)
                {
                    Console.WriteLine( ex.Message);

                }
            
            }
        
        
        }


    }
}
