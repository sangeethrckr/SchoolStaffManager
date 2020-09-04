using System;
using System.Collections.Generic;




namespace StaffClassLibrary
{
    public class InMemoryStaffOperator: IStaffOperator
    {
        public List<Staff> lstStaff ;

        public InMemoryStaffOperator()
        {
            lstStaff = new List<Staff>();
        }

        public bool InsertStaff(Staff staff)
        {
            
            lstStaff.Add(staff);
            return true;
        }
        public bool DeleteStaff(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                lstStaff.Remove(staffFound);
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Staff> GetAllStaffByStaffType(StaffType staffType)
        {
            List<Staff> lstStaffByType = new List<Staff>();
            foreach (Staff staff in lstStaff)
            {
                if (staff.StaffType == staffType)
                {
                    lstStaffByType.Add(staff);
                }
                
            }
            if (lstStaffByType.Count != 0)
            {
                return lstStaffByType;
            }
            else
            {
                return null;
            }
            
        }

        public Staff GetStaffByStaffId(int staffID)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                return staffFound;
                
            }
            else
            {
                
                return null;
            }
        }

        public bool UpdateStaff(int staffID, string name, string phoneNumber, double salary, Address address, string specificData)
        {
            Staff staffFound = FindStaff(staffID);
            if (staffFound != null)
            {
                //StaffHelper.Update(staffFound);
                staffFound.Name = name;
                staffFound.PhoneNumber = phoneNumber;
                staffFound.Salary = salary;
                staffFound.Address = address;

                switch (staffFound.StaffType)
                {
                    case StaffType.teachingStaff:
                        TeachingStaff tStaff = (TeachingStaff)FindStaff(staffID);
                        tStaff.AssignedClass = specificData;
                        break;
                    case StaffType.administrativeStaff:
                        AdminstrativeStaff aStaff = (AdminstrativeStaff)FindStaff(staffID);
                        aStaff.Post = specificData;
                        break;
                    case StaffType.supportStaff:
                        SupportStaff sStaff = (SupportStaff)FindStaff(staffID);
                        sStaff.Post = specificData;
                        break;
                }
                return true;
            }
            else
            {
                return false;
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
            
            return null;

        }

        public StaffType? FindStaffType(int staffId)
        {

            foreach (Staff staff in lstStaff)
            {
                if (staff.StaffId == staffId)
                {
                    return staff.StaffType;

                }
            }
            return null;

            

        }


    }
}
