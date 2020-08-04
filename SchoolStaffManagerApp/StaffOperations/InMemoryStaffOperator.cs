using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            switch (staffType)
            {
                case StaffType.teachingStaff:
                    lstStaff.Add(StaffHelper.AddStaff(StaffType.teachingStaff));
                    break;
                case StaffType.administrativeStaff:
                    lstStaff.Add(StaffHelper.AddStaff(StaffType.administrativeStaff));
                    break;
                case StaffType.supportStaff:
                    lstStaff.Add(StaffHelper.AddStaff(StaffType.supportStaff));
                    break;
            }
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
                if (staff.staffType == staffType)
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
                Console.WriteLine("\nStaff removed!!");
            }
        }

        public void UpdateStaff(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                StaffHelper.Update(staffFound);
                Console.WriteLine("\nStaff removed!!");
            }
        }

        private Staff FindStaff(int staffId)
        {
                        
            foreach (Staff staff in lstStaff)
            {
                if (staff.staffId == staffId)
                {
                    return staff;

                }
            }
            Console.WriteLine("\nStaff not found");
            return null;

        }

        private Staff FindStaff(StaffType staffType)
        {

            foreach (Staff staff in lstStaff)
            {
                if (staff.staffType == staffType)
                {
                    return staff;

                }
            }
            Console.WriteLine("\nStaff not found");
            return null;

        }
    }
}
