using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheetDesktopUI.Models
{
    public class StaffComboxModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public string Cellphone { get; set; }

        public DateTime CreateDate { get; set; }
        public string StaffName
        {
            get 
            {
                return $"{FirstName} {LastName}";
            }
            
        }

    }
}
