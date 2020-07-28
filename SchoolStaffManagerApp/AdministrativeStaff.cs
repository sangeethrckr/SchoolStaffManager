using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStaffManagerApp
{
    public class AdminstrativeStaff : Staff
    {
        private string post;
        public AdminstrativeStaff()
        {
            staffType = StaffType.administrativeStaff;
        }

        public override void AddStaff()
        {
            base.AddStaff();
            
            Console.WriteLine("\nEnter Post\n");
            post = Console.ReadLine();

        }

        public override void ViewDetails()
        {
            base.ViewDetails();

            Console.WriteLine("\nPost : {0}", post);



        }

        protected override int SelectUpdateChoice()
        {
            Console.WriteLine("\nUpdate Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Post");
            return Convert.ToInt32(Console.ReadLine());
        }

        protected override void UpdateSpecificDetails()
        {
            Console.WriteLine("\nEnter updated post");
            post = Console.ReadLine();
        }

    }
}