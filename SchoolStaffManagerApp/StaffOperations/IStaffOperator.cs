using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
