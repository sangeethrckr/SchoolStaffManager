using System;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    public class InputStaffProperties
    {


        public static string AskName()
        {
            Console.WriteLine("\nEnter Name\n");
            return Console.ReadLine();
        }

        public static Address AskAddress()
        {
            Address address = new Address();
            Console.WriteLine("\nEnter Address\nHouse name:");
            address.HouseName = Console.ReadLine();
            Console.WriteLine("Address Line 1:");
            address.City = Console.ReadLine();
            Console.WriteLine("Address line 2:");
            address.State = Console.ReadLine();
            Console.WriteLine("PIN:");
            address.Pin = Convert.ToInt32(Console.ReadLine());
            return address;
        }

        public static Double AskSalary()
        {
            Console.WriteLine("\nEnter Salary\n");
            return Convert.ToDouble(Console.ReadLine());
        }
        

        public static string AskPhoneNumber()
        {
            Console.WriteLine("\nEnter Phone number");
            string inputPhoneNumber = Console.ReadLine();
            string validation = Validator.ValidatePhoneNumber(inputPhoneNumber);
            if (validation == null)
            {
                return inputPhoneNumber;
            }
            else
            {
                Console.WriteLine(validation);
                return AskPhoneNumber();
            }
        }


        

        public static int AskStaffID()
        {
            Console.WriteLine("\nEnter Staff ID\n");
            int inputStaffId = Convert.ToInt32(Console.ReadLine());
            if (Validator.ValidateStaffID(inputStaffId))
            {
                return inputStaffId;
            }
            else
            {
                Console.WriteLine("Staff ID should be between 1 and 500\n");
                return AskStaffID();
            }
        }


        public static string AskSubject()
        {
            Console.WriteLine("\nEnter Subject\n");
            return Console.ReadLine();

            
        }

        public static string AskClass()
        {
            Console.WriteLine("\nEnter Class Assigned");
            return Console.ReadLine();
        }

        public static string AskPost()
        {
            Console.WriteLine("\nEnter Post\n");
            return Console.ReadLine();
        }

        public static StaffType AskStaffType()
        {
            Console.WriteLine("\nChoose Staff Type\n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n");  
            int staffTypeChoice = Convert.ToInt32(Console.ReadLine());

            switch (staffTypeChoice)
            {
                case 1:
                    return StaffType.teachingStaff;

                case 2:
                    return StaffType.administrativeStaff;

                case 3:
                    return StaffType.supportStaff;

                default:
                    Console.WriteLine("\nIncorrect Option");
                    return AskStaffType();
            }
        }
    }
}