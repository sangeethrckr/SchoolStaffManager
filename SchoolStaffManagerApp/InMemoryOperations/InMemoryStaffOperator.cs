using System;
using System.Collections.Generic;
using StaffClassLibrary;



namespace SchoolStaffManagerApp
{
    class InMemoryStaffOperator: IStaffOperator
    {
        public List<Staff> lstStaff ;

        public InMemoryStaffOperator()
        {
            lstStaff = new List<Staff>();
        }

        public void CreateStaff(StaffType staffType)
        {
            Staff newStaff = StaffHelper.AddStaff(staffType);
            lstStaff.Add(newStaff);
        }
        public void DeleteStaff(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                lstStaff.Remove(staffFound);
                Console.WriteLine("\nStaff removed!!");
            }
        }

        public void GetAllStaffByStaffType(StaffType staffType)
        {
            Console.WriteLine("\nDetails of {0}", staffType);
            bool staffFound = false;
            foreach (Staff staff in lstStaff)
            {
                if (staff.StaffType == staffType)
                {
                    StaffHelper.ViewDetails(staff);
                    staffFound = true;
                }
                
            }
            if (!staffFound)
            {
                Console.WriteLine("\nNo {0} found", staffType);
            }
        }

        public void GetStaffByStaffId(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                StaffHelper.ViewDetails(staffFound);
                
            }
            else
            {
                Console.WriteLine("\nStaff not found!!");
            }
        }

        public void UpdateStaff(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                StaffHelper.Update(staffFound);
                Console.WriteLine("\nStaff updated!!");
            }
            else
            {
                Console.WriteLine("\nStaff not found!!");
            }
        }

        private Staff FindStaff(int staffId)
        {
                        
            foreach (Staff staff in lstStaff)
            {
                if (staff.StaffId == staffId)
                {
                    return staff;

                }
            }
            Console.WriteLine("\nStaff not found");
            return null;

        }

        
    }
}
