using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
    public class AdminstrativeStaff : Staff
    {
        public string Post { get; set; }

        public AdminstrativeStaff()
        {
            StaffType = StaffType.administrativeStaff;
            
        }

        

    }
}