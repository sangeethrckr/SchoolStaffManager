﻿using System;
using System.Collections.Generic;
using System.Text;

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
            base.AddStaff();
                
            Console.WriteLine("\nEnter Subject\n");
            subject = Console.ReadLine();

            Console.WriteLine("\nEnter Class Assigned");
            assignedClass = Console.ReadLine();
        }

        public override void ViewDetails()
        {
            Console.WriteLine("\nTeaching Staff Details\nName : {0}", name);

            Console.WriteLine("Staff ID : {0}", staffID);
                        

            Console.WriteLine("Address: {0}, {1}, {2}", address.houseName, address.addressLine1, address.addressLine2);

            Console.WriteLine("Phone Number : {0}", phoneNumber);

            Console.WriteLine("Salary : {0}", salary);

            Console.WriteLine("Subject : {0}", subject);

            Console.WriteLine("Class Assigned: {0}", assignedClass);

        }

        public override void Update()
        {
            base.Update();
            Console.WriteLine("\nUpdate Teaching Details\nWhat do you need to update?\n1.Class Assigned");
            int updateChoice = Convert.ToInt32(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Class Assigned");
                    assignedClass = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }

    }
}