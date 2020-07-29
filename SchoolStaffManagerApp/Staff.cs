using System;
//using System.Collections.Generic;
//using System.Text;

namespace SchoolStaffManagerApp
{
     
    
    public abstract class Staff
    {
        protected int staffID;
        protected string name;
        protected Address address = new Address();
        protected long phoneNumber;
        protected double salary;
        protected StaffType staffType;
              

        public virtual void AddStaff()
        {
            Console.WriteLine("\nEnter Name\n");
            name = Console.ReadLine();

            staffID = HelperMethods.AskStaffID();

            Console.WriteLine("\nEnter Address\nHouse name:");
            address.houseName = Console.ReadLine();
            Console.WriteLine("Address Line 1:");
            address.addressLine1 = Console.ReadLine();
            Console.WriteLine("Address line 2:");
            address.addressLine2 = Console.ReadLine();
            Console.WriteLine("PIN:");
            address.pin = Convert.ToInt32(Console.ReadLine());

            phoneNumber = HelperMethods.AskPhoneNumber();

            Console.WriteLine("\nEnter Salary\n");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void ViewDetails()
        {
            Console.WriteLine("\nTeaching Staff Details\n\nName : {0}", name);

            Console.WriteLine("Staff ID : {0}", staffID);


            Console.WriteLine("\nAddress: \n\t{0}\n\t{1}\n\t{2}\n\tPIN: {3}", address.houseName, address.addressLine1, address.addressLine2,address.pin);

            Console.WriteLine("\tPhone Number : {0}", phoneNumber);

            Console.WriteLine("\nSalary : {0}", salary);
        }

        protected abstract int SelectUpdateChoice();
        protected abstract void UpdateSpecificDetails();

        public void Update()
        {
            
            int updateChoice = SelectUpdateChoice();

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Address\nHouse name:");
                    address.houseName = Console.ReadLine();
                    Console.WriteLine("Addres Line 1:");
                    address.addressLine1 = Console.ReadLine();
                    Console.WriteLine("Address line 2:");
                    address.addressLine2 = Console.ReadLine();
                    Console.WriteLine("PIN:");
                    address.pin = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("\nEnter updated Salary\n");
                    salary = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    UpdateSpecificDetails();
                    break;
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }
                       

    }
}