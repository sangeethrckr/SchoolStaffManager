using System;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    public class AdministrativeStaffHelper
    {
        public static AdminstrativeStaff AddStaff()
        {
            AdminstrativeStaff adminStaff = new AdminstrativeStaff();

            StaffHelper.AskCommonDetails(adminStaff);

            adminStaff.Post = InputStaffProperties.AskPost();
            
            //Console.WriteLine("\nAdministrative Staff added");
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
                adminStaff.Post = InputStaffProperties.AskPost();
            }
        }

    }
}
