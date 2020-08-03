using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
    public class TeachingStaff : Staff
    {
        public string subject;
        public string assignedClass;

        public TeachingStaff()
        {
            staffType = StaffType.teachingStaff;
            

        }
        

    }
}