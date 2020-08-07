using System;
using System.Collections.Generic;


namespace SchoolStaffManagerApp
{
    public class Address
    {
        public string HouseName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int Pin { get; set; }

        public Address()
        {
            HouseName = "nil";
            AddressLine1 = "nil";
            AddressLine2 = "nil";

        }
    }
}
