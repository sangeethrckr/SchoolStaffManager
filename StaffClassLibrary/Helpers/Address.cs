using System;
using System.Collections.Generic;


namespace StaffClassLibrary
{
    public class Address
    {
        public string HouseName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pin { get; set; }

        public Address()
        {
            HouseName = "nil";
            City = "nil";
            State = "nil";

        }
    }
}
