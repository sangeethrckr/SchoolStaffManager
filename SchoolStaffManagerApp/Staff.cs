using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStaffManagerApp
{
    
    public class Address
    {
        public string houseName;
        public string addressLine1;
        public string addressLine2;
    }

    public enum StaffType
    {
        teachingStaff,
        administrativeStaff,
        supportStaff
    }

    public abstract class Staff
    {
        protected int _staffID;
        protected int StaffID
        {
            get
            {
                return _staffID;
            }

            set
            {

                if (value > 0 && value < 500)
                    _staffID = StaffID;
                else
                {
                    Console.WriteLine("\nStaff ID should be between 1 and 500\n");
                    _staffID = 0;
                }

            }
        }
        protected string name;
        protected Address address = new Address();
        protected long _phoneNumber;
        protected string PhoneNumber
        {
            get
            {
                return Convert.ToString(_phoneNumber);
            }
            set
            {
                if (long.TryParse(value, out _phoneNumber)) ;
                else
                {
                    Console.WriteLine("Phone Number Should be 10 digit integer\n");
                    _phoneNumber = 0;
                }

            }
        }
        protected double salary;

        protected StaffType staffType;

        

        public abstract void AddStaff();

        public abstract void ViewDetails();

        public abstract void Update();



    }
}