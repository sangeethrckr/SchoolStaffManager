using System;
//using System.Collections.Generic;
//using System.Text;

namespace StaffClassLibrary
{
    public class SupportStaff : Staff
    {
        public string Post { get; set; }

        public SupportStaff() : base()
        {
            StaffType = StaffType.supportStaff;
            
        }

        
    }
}