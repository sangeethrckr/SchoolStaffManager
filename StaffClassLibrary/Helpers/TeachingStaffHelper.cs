using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClassLibrary
{
    public class TeachingStaffHelper
    {
        public static TeachingStaff AddStaff()
        {
            TeachingStaff teachingStaff = new TeachingStaff();

            teachingStaff.Name = Validator.AskName();
            teachingStaff.StaffId = Validator.AskStaffID();

            teachingStaff.Address = Validator.AskAddress();
            teachingStaff.PhoneNumber = Validator.AskPhoneNumber();
            teachingStaff.Salary = Validator.AskSalary();
            teachingStaff.Subject = Validator.AskSubject();
            teachingStaff.AssignedClass = Validator.AskClass();


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
                teachingStaff.AssignedClass = Validator.AskClass();
            }
        }
    }
}
