using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClassLibrary
{
    public class SupportStaffHelper
    {
        public static SupportStaff AddStaff()
        {
            SupportStaff supportStaff = new SupportStaff();

            supportStaff.Name = Validator.AskName();
            supportStaff.StaffId = Validator.AskStaffID();

            supportStaff.Address = Validator.AskAddress();
            supportStaff.PhoneNumber = Validator.AskPhoneNumber();
            supportStaff.Salary = Validator.AskSalary();
            supportStaff.Post = Validator.AskPost();



            Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", supportStaff.StaffId);
            return supportStaff;
        }

        public static void ViewDetails(SupportStaff supportStaff)
        {
            StaffHelper.ViewCommonDetails(supportStaff);

            Console.WriteLine("\nPost : {0}", supportStaff.Post);


        }

        public static void Update(SupportStaff supportStaff)
        {
            int updateChoice;
            Console.WriteLine("\nUpdate Administrative Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Post\n");

            updateChoice = Convert.ToInt32(Console.ReadLine());

            if (updateChoice == 1 || updateChoice == 2)
            {
                StaffHelper.CommonUpdate(supportStaff, updateChoice);
            }
            else
            {
                Console.WriteLine("\nUpdate Post");
                supportStaff.Post = Validator.AskPost();
            }
        }

    }
}
