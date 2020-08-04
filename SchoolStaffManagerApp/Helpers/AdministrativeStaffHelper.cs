using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStaffManagerApp
{
    class AdministrativeStaffHelper
    {
        public static Staff AddStaff()
        {
            AdminstrativeStaff adminStaff = new AdminstrativeStaff();

            adminStaff.name = Validator.AskName();
            adminStaff.staffId = Validator.AskStaffID();

            adminStaff.address = Validator.AskAddress();
            adminStaff.phoneNumber = Validator.AskPhoneNumber();
            adminStaff.salary = Validator.AskSalary();
            adminStaff.post = Validator.AskPost();
            


            Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", adminStaff.staffId);
            return adminStaff;
        }

        public static void ViewDetails(AdminstrativeStaff adminStaff)
        {
            StaffHelper.ViewCommonDetails(adminStaff);

            Console.WriteLine("\nPost : {0}", adminStaff.post);

            
        }

        public static void Update(AdminstrativeStaff adminStaff)
        {
            int updateChoice;
            Console.WriteLine("\nUpdate Administrative Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Post\n");

            updateChoice = Convert.ToInt32(Console.ReadLine());

            if (updateChoice == 1 || updateChoice == 2)
            {
                StaffHelper.CommonUpdate(adminStaff, updateChoice);
            }
            else
            {
                Console.WriteLine("\nUpdate Post");
                adminStaff.post = Validator.AskPost();
            }
        }

    }
}
