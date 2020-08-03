using System;


namespace SchoolStaffManagerApp
{
    public class Validator
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
            address.houseName = Console.ReadLine();
            Console.WriteLine("Address Line 1:");
            address.addressLine1 = Console.ReadLine();
            Console.WriteLine("Address line 2:");
            address.addressLine2 = Console.ReadLine();
            Console.WriteLine("PIN:");
            address.pin = Convert.ToInt32(Console.ReadLine());
            return address;
        }

        public static Double AskSalary()
        {
            Console.WriteLine("\nEnter Salary\n");
            return Convert.ToDouble(Console.ReadLine());
        }
        private static long ValidatePhoneNumber(string phoneNumber)
        {
            long outputPhoneNumber;
            if (long.TryParse(phoneNumber, out outputPhoneNumber))
            {

                if (phoneNumber.Length == 10)
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

        public static long AskPhoneNumber()
        {
            Console.WriteLine("\nEnter Phone number");
            string inputPhoneNumber = Console.ReadLine();
            if (ValidatePhoneNumber(inputPhoneNumber) != -1)
            {
                return  ValidatePhoneNumber(inputPhoneNumber);
            }
            else
            {
                return AskPhoneNumber();
            }
        }


        private static bool ValidateStaffID(int inputStaffId)
        {
            if (inputStaffId > 0 && inputStaffId <= 500)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int AskStaffID()
        {
            Console.WriteLine("\nEnter Staff ID\n");
            int inputStaffId = Convert.ToInt32(Console.ReadLine());
            if (ValidateStaffID(inputStaffId))
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
    }
}