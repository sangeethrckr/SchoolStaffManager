using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStaffManagerApp
{
    public class TeachingStaffHelper
    {
        public static Staff AddStaff()
        {
            TeachingStaff teachingStaff = new TeachingStaff();

            teachingStaff.name = Validator.AskName();
            teachingStaff.staffId = Validator.AskStaffID();

            teachingStaff.address = Validator.AskAddress();
            teachingStaff.phoneNumber = Validator.AskPhoneNumber();
            teachingStaff.salary = Validator.AskSalary();
            teachingStaff.subject = Validator.AskSubject();
            teachingStaff.assignedClass = Validator.AskClass();


            Console.WriteLine("\nTeacher Staff added\tStaffID : {0}", teachingStaff.staffId);
            return teachingStaff;
        }

        public static void ViewDetails(TeachingStaff teachingStaff)
        {
            StaffHelper.ViewCommonDetails(teachingStaff);

            Console.WriteLine("\nSubject : {0}", teachingStaff.subject);

            Console.WriteLine("Class Assigned: {0}", teachingStaff.assignedClass);
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
                teachingStaff.assignedClass = Validator.AskClass();
            }
        }
    }
}
