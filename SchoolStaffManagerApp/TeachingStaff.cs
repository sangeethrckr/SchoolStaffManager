using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolStaffManagerApp
{
    class TeachingStaff : Staff
    {
        string subject;
        string assignedClass;

        public TeachingStaff()
        {
            staffType = StaffType.teachingStaff;
        }
        public override void AddStaff()
        {

            Console.WriteLine("\nEnter Name\n");
            name = Console.ReadLine();

            Console.WriteLine("\nEnter Staff ID\n");
            StaffID = Convert.ToInt32(Console.ReadLine());
            if (StaffID == 0)
            {
                Console.WriteLine("\nEnter Staff ID\n");
                StaffID = Convert.ToInt32(Console.ReadLine());
            }

            Console.WriteLine("\nEnter Address\nHouse name:");
            address.houseName = Console.ReadLine();
            Console.WriteLine("Address Line 1:");
            address.addressLine1 = Console.ReadLine();
            Console.WriteLine("Address line 2:");
            address.addressLine2 = Console.ReadLine();

            Console.WriteLine("\nEnter Phone Number\n");
            PhoneNumber = Console.ReadLine();
            if(PhoneNumber == "0")
            {
                Console.WriteLine("\nEnter Phone Number\n");
                PhoneNumber = Console.ReadLine();
            }


            Console.WriteLine("\nEnter Salary\n");
            salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nEnter Subject\n");
            subject = Console.ReadLine();

            Console.WriteLine("\nEnter Class Assigned");
            assignedClass = Console.ReadLine();
        }

        public override void ViewDetails()
        {
            Console.WriteLine("\nTeaching Staff Details\nName : {0}", name);

            Console.WriteLine("Staff ID : {0}", StaffID);
                        

            Console.WriteLine("Address: {0}, {1}, {2}", address.houseName, address.addressLine1, address.addressLine2);

            Console.WriteLine("Phone Number : {0}", PhoneNumber);

            Console.WriteLine("Salary : {0}", salary);

            Console.WriteLine("Subject : {0}", subject);

            Console.WriteLine("Class Assigned: {0}", assignedClass);

        }

        public override void Update()
        {
            Console.WriteLine("\nUpdate Teaching Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Class Assigned");
            int updateChoice = Convert.ToInt32(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Address\nHouse name:");
                    address.houseName = Console.ReadLine();
                    Console.WriteLine("Addres Line 1:");
                    address.addressLine1 = Console.ReadLine();
                    Console.WriteLine("Address line 2:");
                    address.addressLine2 = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("\nEnter updated Salary\n");
                    salary = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
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