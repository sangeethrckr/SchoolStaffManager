using System;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    public class TeachingStaffHelper
    {
        public static TeachingStaff AddStaff()
        {
            TeachingStaff teachingStaff = new TeachingStaff();

            StaffHelper.AskCommonDetails(teachingStaff);

            teachingStaff.Subject = InputStaffProperties.AskSubject();
            teachingStaff.AssignedClass = InputStaffProperties.AskClass();

            Console.WriteLine("\nTeacher Staff added\tStaffID : {0}", teachingStaff.StaffId);
            return teachingStaff;
        }

        public static void ViewDetails(TeachingStaff teachingStaff)
        {
            StaffHelper.ViewCommonDetails(teachingStaff);

            Console.WriteLine("\nSubject : {0}", teachingStaff.Subject);

            Console.WriteLine("Class Assigned: {0}", teachingStaff.AssignedClass);
        }

        public static void Update(TeachingStaff teachingStaff)
        {
            int updateChoice;
            Console.WriteLine("\nUpdate Teacher Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Class Assigned\n");

            updateChoice = Convert.ToInt32(Console.ReadLine());

            if(updateChoice == 1 || updateChoice == 2)
            {
                StaffHelper.CommonUpdate(teachingStaff,updateChoice);
            }
            else
            {
                Console.WriteLine("\nUpdate Class Assigned");
                teachingStaff.AssignedClass = InputStaffProperties.AskClass();
            }
        }
    }
}
