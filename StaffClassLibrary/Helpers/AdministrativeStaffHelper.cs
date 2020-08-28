using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClassLibrary
{
    public class AdministrativeStaffHelper
    {
        public static AdminstrativeStaff AddStaff()
        {
            AdminstrativeStaff adminStaff = new AdminstrativeStaff();

            adminStaff.Name = Validator.AskName();
            adminStaff.StaffId = Validator.AskStaffID();

            adminStaff.Address = Validator.AskAddress();
            adminStaff.PhoneNumber = Validator.AskPhoneNumber();
            adminStaff.Salary = Validator.AskSalary();
            adminStaff.Post = Validator.AskPost();
            


            Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", adminStaff.StaffId);
            return adminStaff;
        }

        public static void ViewDetails(AdminstrativeStaff adminStaff)
        {
            StaffHelper.ViewCommonDetails(adminStaff);

            Console.WriteLine("\nPost : {0}", adminStaff.Post);

            
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
                adminStaff.Post = Validator.AskPost();
            }
        }

    }
}
