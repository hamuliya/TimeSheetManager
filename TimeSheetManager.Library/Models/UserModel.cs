using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetManager.Library.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Cellphone { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
