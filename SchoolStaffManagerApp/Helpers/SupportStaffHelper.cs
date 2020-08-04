using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStaffManagerApp
{
    class SupportStaffHelper
    {
        public static Staff AddStaff()
        {
            SupportStaff supportStaff = new SupportStaff();

            supportStaff.name = Validator.AskName();
            supportStaff.staffId = Validator.AskStaffID();

            supportStaff.address = Validator.AskAddress();
            supportStaff.phoneNumber = Validator.AskPhoneNumber();
            supportStaff.salary = Validator.AskSalary();
            supportStaff.post = Validator.AskPost();



            Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", supportStaff.staffId);
            return supportStaff;
        }

        public static void ViewDetails(SupportStaff supportStaff)
        {
            StaffHelper.ViewCommonDetails(supportStaff);

            Console.WriteLine("\nPost : {0}", supportStaff.post);


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
                supportStaff.post = Validator.AskPost();
            }
        }

    }
}
