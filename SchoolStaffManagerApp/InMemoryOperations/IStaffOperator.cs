using System;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
     interface IStaffOperator
    {

        void CreateStaff(StaffType staffType);

        void DeleteStaff(int staffID);

        void GetAllStaffByStaffType(StaffType staffType);

        void GetStaffByStaffId(int staffID);

        void UpdateStaff(int staffID);

    }
}
