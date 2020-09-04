using System;
using StaffClassLibrary;

namespace SchoolStaffManagerApp

{
    public  class  StaffHelper
    {
        
        public static Staff CreateStaff(StaffType staffType)
        {
            

            switch (staffType)
            {

                case StaffType.teachingStaff:
                    TeachingStaff teachingStaff = new TeachingStaff();
                    AskCommonDetails(teachingStaff);
                    teachingStaff.Subject = InputStaffProperties.AskSubject();
                    teachingStaff.AssignedClass = InputStaffProperties.AskClass();
                    return teachingStaff;

                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = new AdminstrativeStaff();
                    AskCommonDetails(adminStaff);
                    adminStaff.Post = InputStaffProperties.AskPost();
                    return adminStaff;

                case StaffType.supportStaff:
                    SupportStaff supportStaff = new SupportStaff();
                    AskCommonDetails(supportStaff);
                    supportStaff.Post = InputStaffProperties.AskPost();
                    return supportStaff;

                default:
                    return null;
            }
        }

        
        public static void ViewDetails(Staff staff)
        {
           
            switch (staff.StaffType)
            {
                case StaffType.teachingStaff:
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    ViewCommonDetails(teachingStaff);
                    Console.WriteLine("\nSubject : {0}", teachingStaff.Subject);
                    Console.WriteLine("Class Assigned: {0}", teachingStaff.AssignedClass);
                    break;

                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = (AdminstrativeStaff)staff;
                    ViewCommonDetails(adminStaff);
                    Console.WriteLine("\nPost : {0}", adminStaff.Post);
                    break;

                case StaffType.supportStaff:
                    SupportStaff supportStaff = (SupportStaff)staff;
                    ViewCommonDetails(supportStaff);
                    Console.WriteLine("\nPost : {0}", supportStaff.Post);
                    break;
                
            }

        }

        

        

        public static void ViewCommonDetails(Staff staff)
        {
            Console.WriteLine("\nStaff Details\n\nName : {0}", staff.Name);
            Console.WriteLine("Staff ID : {0}", staff.StaffId);
            Console.WriteLine("\nAddress: \n\t{0}\n\t{1}\n\t{2}\n\tPIN: {3}", staff.Address.HouseName, staff.Address.City, staff.Address.State, staff.Address.Pin);
            Console.WriteLine("\tPhone Number : {0}", staff.PhoneNumber);
            Console.WriteLine("\nSalary : {0}", staff.Salary);
        }

        

        public static void AskCommonDetails(Staff staff)
        {
            staff.Name = InputStaffProperties.AskName();
            staff.StaffId = InputStaffProperties.AskStaffID();
            staff.Address = InputStaffProperties.AskAddress();
            staff.PhoneNumber = InputStaffProperties.AskPhoneNumber();
            staff.Salary = InputStaffProperties.AskSalary();
        }

    }
}
