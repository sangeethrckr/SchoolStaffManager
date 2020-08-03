using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolStaffManagerApp
{
    public  class  StaffHelper
    {
        
        public static Staff AddStaff(StaffType staffType)
        {
            

            switch (staffType)
            {

                case StaffType.teachingStaff:
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
                    
                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = new AdminstrativeStaff();

                    adminStaff.name = Validator.AskName();
                    adminStaff.staffId = Validator.AskStaffID();

                    adminStaff.address = Validator.AskAddress();
                    adminStaff.phoneNumber = Validator.AskPhoneNumber();
                    adminStaff.salary = Validator.AskSalary();
                    adminStaff.post = Validator.AskPost();

                    Console.WriteLine("\nAdministrative Staff added\tStaffID : {0}", adminStaff.staffId);
                    return adminStaff;
                case StaffType.supportStaff:
                    SupportStaff supportStaff = new SupportStaff();

                    supportStaff.name = Validator.AskName();
                    supportStaff.staffId = Validator.AskStaffID();

                    supportStaff.address = Validator.AskAddress();
                    supportStaff.phoneNumber = Validator.AskPhoneNumber();
                    supportStaff.salary = Validator.AskSalary();
                    supportStaff.post = Validator.AskPost();

                    Console.WriteLine("\nSupport Staff added\tStaffID : {0}", supportStaff.staffId);
                    return supportStaff;
                default:
                    return null;
            }
        }

        public static void ViewDetails(Staff staff)
        {
           
            Console.WriteLine("\nStaff Details\n\nName : {0}", staff.name);

            Console.WriteLine("Staff ID : {0}", staff.staffId);


            Console.WriteLine("\nAddress: \n\t{0}\n\t{1}\n\t{2}\n\tPIN: {3}", staff.address.houseName, staff.address.addressLine1, staff.address.addressLine2, staff.address.pin);

            Console.WriteLine("\tPhone Number : {0}", staff.phoneNumber);

            Console.WriteLine("\nSalary : {0}", staff.salary);


            switch (staff.staffType)
            {
                case StaffType.teachingStaff:
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    Console.WriteLine("\nSubject : {0}", teachingStaff.subject);

                    Console.WriteLine("Class Assigned: {0}", teachingStaff.assignedClass);
                    break;

                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = (AdminstrativeStaff)staff;
                    Console.WriteLine("\nPost : {0}", adminStaff.post);
                    break;
                case StaffType.supportStaff:
                    SupportStaff supportStaff = new SupportStaff();
                    Console.WriteLine("\nPost : {0}", supportStaff.post);
                    break;
                default:
                    break;
            }

        }



        public static void Update(Staff staff)
        {
            int updateChoice;
            switch (staff.staffType)
            {
                case StaffType.teachingStaff:
                    Console.WriteLine("\nUpdate Teacher Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Class Assigned");
                    break;

                case StaffType.administrativeStaff:
                    Console.WriteLine("\nUpdate Administrative Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Post");
                    break;
                case StaffType.supportStaff:
                    Console.WriteLine("\nUpdate Support Staff Details\nWhat do you need to update?\n1.Address\n2.Salary\n3.Post");
                    break;
                default:
                    break;
            }

            updateChoice = Convert.ToInt32(Console.ReadLine());

            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nEnter updated Address\nHouse name:");
                    staff.address.houseName = Console.ReadLine();
                    Console.WriteLine("Addres Line 1:");
                    staff.address.addressLine1 = Console.ReadLine();
                    Console.WriteLine("Address line 2:");
                    staff.address.addressLine2 = Console.ReadLine();
                    Console.WriteLine("PIN:");
                    staff.address.pin = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.WriteLine("\nEnter updated Salary\n");
                    staff.salary = Convert.ToDouble(Console.ReadLine());
                    break;
                case 3:
                    switch (staff.staffType)
                    {
                        case StaffType.teachingStaff:
                            TeachingStaff teachingStaff = (TeachingStaff)staff;
                            Console.WriteLine("\nEnter updated Class Assigned");
                            teachingStaff.assignedClass = Console.ReadLine();
                            break;

                        case StaffType.administrativeStaff:
                            AdminstrativeStaff adminStaff = (AdminstrativeStaff)staff;
                            Console.WriteLine("\nEnter updated post");
                            adminStaff.post = Console.ReadLine();
                            break;
                        case StaffType.supportStaff:
                            SupportStaff supportStaff = new SupportStaff();
                            Console.WriteLine("\nEnter updated post");
                            supportStaff.post = Console.ReadLine();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("\nIncorrect Option\n");
                    break;
            }
        }

    }
}
