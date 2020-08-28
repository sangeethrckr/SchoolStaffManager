using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffClassLibrary

{
    public  class  StaffHelper
    {
        
        public static Staff AddStaff(StaffType staffType)
        {
            

            switch (staffType)
            {

                case StaffType.teachingStaff:
                    return TeachingStaffHelper.AddStaff();
                    
                case StaffType.administrativeStaff:
                    return AdministrativeStaffHelper.AddStaff();
                case StaffType.supportStaff:
                    return SupportStaffHelper.AddStaff();
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
                    TeachingStaffHelper.ViewDetails(teachingStaff);
                    break;

                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = (AdminstrativeStaff)staff;
                    AdministrativeStaffHelper.ViewDetails(adminStaff);
                    break;
                case StaffType.supportStaff:
                    SupportStaff supportStaff = (SupportStaff)staff;
                    SupportStaffHelper.ViewDetails(supportStaff);
                    break;
                
            }

        }

        

        public static void Update(Staff staff)
        {
            switch (staff.StaffType)
            {
                case StaffType.teachingStaff:
                    TeachingStaff teachingStaff = (TeachingStaff)staff;
                    TeachingStaffHelper.Update(teachingStaff);
                    break;

                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = (AdminstrativeStaff)staff;
                    AdministrativeStaffHelper.Update(adminStaff);
                    break;
                case StaffType.supportStaff:
                    SupportStaff supportStaff = (SupportStaff)staff;
                    SupportStaffHelper.Update(supportStaff);
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

        public static void CommonUpdate(Staff staff, int updateChoice)
        {
            switch (updateChoice)
            {
                case 1:
                    Console.WriteLine("\nUpdate Address\n");
                    staff.Address = Validator.AskAddress();
                    break;
                case 2:
                    Console.WriteLine("\nUpdate Salary\n");
                    staff.Salary = Validator.AskSalary();
                    break;
            }
        }

    }
}
