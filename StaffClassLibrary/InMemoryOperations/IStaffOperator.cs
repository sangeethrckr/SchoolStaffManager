using System;
using System.Collections.Generic;

namespace StaffClassLibrary
{
     public interface IStaffOperator
    {

        bool InsertStaff(Staff staff);

        bool DeleteStaff(int staffID);

        List<Staff> GetAllStaffByStaffType(StaffType staffType);

        Staff GetStaffByStaffId(int staffID);

        bool UpdateStaff(int staffID, string name, string phoneNumber, double salary, Address address, string specificData);

        StaffType? FindStaffType(int staffId);

    }
}
