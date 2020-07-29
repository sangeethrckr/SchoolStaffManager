using System;


namespace SchoolStaffManagerApp
{
    public class HelperMethods
    {
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
    }
}