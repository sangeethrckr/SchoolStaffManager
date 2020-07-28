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
        protected int staffID;
        protected string name;
        protected Address address = new Address();
        protected long phoneNumber;
        protected double salary;
        protected StaffType staffType;
              

        public virtual void AddStaff()
        {
            Console.WriteLine("\nEnter Name\n");
            name = Console.ReadLine();

            AskStaffID();

            Console.WriteLine("\nEnter Address\nHouse name:");
            address.houseName = Console.ReadLine();
            Console.WriteLine("Address Line 1:");
            address.addressLine1 = Console.ReadLine();
            Console.WriteLine("Address line 2:");
            address.addressLine2 = Console.ReadLine();

            Console.WriteLine("\nEnter Phone Number\n");
            phoneNumber = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("\nEnter Salary\n");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public abstract void ViewDetails();

        public virtual void Update()
        {
            Console.WriteLine("\nUpdate Staff Details\nWhat do you need to update?\n1.Address\n2.Salary");
            int updateChoice = Convert.ToInt32(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Address\nHouse name:");
                    address.houseName = Console.ReadLine();
                    Console.WriteLine("Addres Line 1:");
                    address.addressLine1 = Console.ReadLine();
                    Console.WriteLine("Address line 2:");
                    address.addressLine2 = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("\nEnter updated Salary\n");
                    salary = Convert.ToDouble(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }

        private bool ValidateStaffID(int staffID)
        {
            if(staffID>0 && staffID <= 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AskStaffID()
        {
            Console.WriteLine("\nEnter Staff ID\n");
            int inputStaffID = Convert.ToInt32(Console.ReadLine());
            if (ValidateStaffID(inputStaffID))
            {
                staffID = inputStaffID;
            }
            else
            {
                Console.WriteLine("Staff ID should be between 1 and 500\n");
                AskStaffID();
            }
        }



    }
}