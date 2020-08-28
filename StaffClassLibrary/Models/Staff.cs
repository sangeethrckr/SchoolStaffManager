using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace StaffClassLibrary
{

    [XmlInclude(typeof(TeachingStaff)), XmlInclude(typeof(AdminstrativeStaff)), XmlInclude(typeof(SupportStaff))]
    public class Staff
    {

        public int StaffId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public double Salary { get; set; }
        public StaffType StaffType { get; set; }
             
                                      

    }

    
}