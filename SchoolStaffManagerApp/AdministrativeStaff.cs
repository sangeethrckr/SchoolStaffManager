using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
    public class AdminstrativeStaff : Staff
    {
        private string post;
        public AdminstrativeStaff()
        {
            staffType = StaffType.administrativeStaff;
        }

        public override void AddStaff(string predcessorStaffID)
        {
            if (predcessorStaffID == null)
            {
                staffID = "A1";
            }
            else
            {
                int staffIdNum = Convert.ToInt32(predcessorStaffID.Remove(0, 1));
                staffID = "A" + Convert.ToString(staffIdNum + 1);
            }

            base.AddStaff(predcessorStaffID);
            
            Console.WriteLine("\nEnter Post\n");
            post = Console.ReadLine();

            Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", staffID);

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