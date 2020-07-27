using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStaffManagerApp
{
    
    class Address
    {
        public string houseName;
        public string addressLine1;
        public string addressLine2;
    }

    enum StaffType
    {
        teachingStaff,
        administrativeStaff,
        supportStaff
    }

    abstract class Staff
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
                    throw new ArgumentOutOfRangeException();

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
                    throw new FormatException();

            }
        }
        protected double salary;

        protected StaffType staffType;

        

        public abstract void AddStaff();

        public abstract void ViewDetails();

        public abstract void Update();



    }
}