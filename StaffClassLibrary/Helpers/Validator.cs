using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClassLibrary
{
    public class Validator
    {
        public static string ValidatePhoneNumber(string phoneNumber)
        {
            long outputPhoneNumber;
            if (long.TryParse(phoneNumber, out outputPhoneNumber))
            {

                if (phoneNumber.Length == 10)
                {
                    return null;
                }
                else
                {
                    return("Phone number should have 10 digits");
                    
                }
            }
            else
            {
                return("\nPhone number should not contain characters");
                
            }
        }

        public static bool ValidateStaffID(int inputStaffId)
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

    }
}
