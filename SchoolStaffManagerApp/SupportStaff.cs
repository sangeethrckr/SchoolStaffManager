using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStaffManagerApp
{
    public class SupportStaff : Staff
    {
        private string post;

        public SupportStaff()
        {
            staffType = StaffType.supportStaff;
        }

        public override void AddStaff()
        {
            base.AddStaff();

            Console.WriteLine("\nEnter Post\n");
            post = Console.ReadLine();

        }

        public override void ViewDetails()
        {
            Console.WriteLine("\nSupport Staff Details\nName : {0}", name);

            Console.WriteLine("Staff ID : {0}", staffID);

            

            Console.WriteLine("Address: {0}, {1}, {2}", address.houseName, address.addressLine1, address.addressLine2);

            Console.WriteLine("Phone Number : {0}", phoneNumber);

            Console.WriteLine("Salary : {0}", salary);

            Console.WriteLine("Post : {0}", post);



        }

        public override void Update()
        {
            base.Update();
            Console.WriteLine("\nUpdate Support Details\nWhat do you need to update?\n1.Post");
            int updateChoice = Convert.ToInt32(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Post");
                    post = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }

    }
}