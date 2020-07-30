using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
    public class TeachingStaff : Staff
    {
        private string subject;
        private string assignedClass;

        public TeachingStaff()
        {
            staffType = StaffType.teachingStaff;
            
        }
        public override void AddStaff()
        {
            

            base.AddStaff( );
                
            Console.WriteLine("\nEnter Subject\n");
            subject = Console.ReadLine();

            Console.WriteLine("\nEnter Class Assigned");
            assignedClass = Console.ReadLine();

            Console.WriteLine("\nTeacher Staff added\tStaffID : {0}",staffId);
        }

        public override void ViewDetails()
        {
            base.ViewDetails();

            Console.WriteLine("\nSubject : {0}", subject);

            Console.WriteLine("Class Assigned: {0}", assignedClass);

        }

        protected override int SelectUpdateChoice()
        {
            Console.WriteLine("\nUpdate Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Class Assigned");
            return Convert.ToInt32(Console.ReadLine());
        }

        protected override void UpdateSpecificDetails()
        {
            Console.WriteLine("\nEnter updated Class Assigned");
            assignedClass = Console.ReadLine();
        }

    }
}