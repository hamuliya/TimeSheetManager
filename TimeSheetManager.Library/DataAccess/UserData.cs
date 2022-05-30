using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TimeSheetManager.Library.Internal.DataAccess;
using TimeSheetManager.Library.Models;

namespace TimeSheetManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            return sql.LoadData<UserModel,dynamic>("dbo.spUserLookup", new { Id = Id },"TimeSheetDB");
        }

    }
}
