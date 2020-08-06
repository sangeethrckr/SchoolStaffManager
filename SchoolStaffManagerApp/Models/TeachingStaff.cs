using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
    public class TeachingStaff : Staff
    {
        public string Subject { get; set; }
        public string AssignedClass { get; set; }

        public TeachingStaff()
        {
            StaffType = StaffType.teachingStaff;
            

        }
        

    }
}