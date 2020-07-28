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
        public int pin;
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
            Console.WriteLine("PIN:");
            address.pin = Convert.ToInt32(Console.ReadLine());

            AskPhoneNumber();

            Console.WriteLine("\nEnter Salary\n");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void ViewDetails()
        {
            Console.WriteLine("\nTeaching Staff Details\n\nName : {0}", name);

            Console.WriteLine("Staff ID : {0}", staffID);


            Console.WriteLine("\nAddress: \n\t{0}\n\t{1}\n\t{2}\n\tPIN: {3}", address.houseName, address.addressLine1, address.addressLine2,address.pin);

            Console.WriteLine("\tPhone Number : {0}", phoneNumber);

            Console.WriteLine("\nSalary : {0}", salary);
        }

        protected abstract int SelectUpdateChoice();
        protected abstract void UpdateSpecificDetails();

        public virtual void Update()
        {
            
            int updateChoice = SelectUpdateChoice();

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Address\nHouse name:");
                    address.houseName = Console.ReadLine();
                    Console.WriteLine("Addres Line 1:");
                    address.addressLine1 = Console.ReadLine();
                    Console.WriteLine("Address line 2:");
                    address.addressLine2 = Console.ReadLine();
                    Console.WriteLine("PIN:");
                    address.pin = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("\nEnter updated Salary\n");
                    salary = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    UpdateSpecificDetails();
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

        private long ValidatePhoneNumber(string phoneNumber)
        {
            long outputPhoneNumber;
            if (long.TryParse(phoneNumber, out outputPhoneNumber))
            {
                
                if(phoneNumber.Length == 10)
                {
                    return outputPhoneNumber;
                }
                else
                {
                    Console.WriteLine("\nPhone number should have 10 digits");
                    return -1;
                }
            }
            else
            {
                Console.WriteLine("\nPhone number should not contain characters");
                return -1;
            }
        }

        private void AskPhoneNumber()
        {
            Console.WriteLine("\nEnter Phone number");
            string inputPhoneNumber = Console.ReadLine();
            if (ValidatePhoneNumber(inputPhoneNumber) != -1)
            {
                phoneNumber = ValidatePhoneNumber(inputPhoneNumber);
            }
            else
            {
                AskPhoneNumber();
            }
        }

    }
}