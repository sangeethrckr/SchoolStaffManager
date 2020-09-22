using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StaffClassLibrary;
using Newtonsoft.Json.Linq;

namespace SchoolStaffWebAPI.Controllers
{
    public class StaffController : ApiController
    {
        DatabaseStaffOperator staffOperator = new DatabaseStaffOperator();



        [HttpGet]
        public List<Staff> GetStaffByType(string staffType)
        {
            switch (staffType.ToLower())
            {
                case "teaching":
                    return staffOperator.GetAllStaffByStaffType(StaffType.teachingStaff);
                    
                case "admin":
                    return staffOperator.GetAllStaffByStaffType(StaffType.administrativeStaff);
                    
                case "support":
                    return staffOperator.GetAllStaffByStaffType(StaffType.supportStaff);

                default:
                    return null;
            }


        }

        [HttpGet]
        public Staff GetStaffById(int id)
        {
            
            return staffOperator.GetStaffByStaffId(id);

        }

        [HttpPost]
        public void InsertStaff([FromBody] JObject staff)
        {
            int staffType = (int)staff["StaffType"];
            switch (staffType)
            {
                case 0:
                    staffOperator.InsertStaff(staff.ToObject<TeachingStaff>());
                    break;
                case 1:
                    staffOperator.InsertStaff(staff.ToObject<AdminstrativeStaff>());
                    break;
                case 2:
                    staffOperator.InsertStaff(staff.ToObject<SupportStaff>());
                    break;
            }
            
            
        }

        [HttpPut]
        public void UpdateStaff(int id, [FromBody] JObject updateString)
        {
            
            string name = updateString["Name"].ToString();
            string phoneNumber = updateString["PhoneNumber"].ToString();
            double salary = (double)updateString["Salary"];
            Address address = new Address();
            address.HouseName = updateString["Address"]["HouseName"].ToString();
            address.City = updateString["Address"]["City"].ToString();
            address.State = updateString["Address"]["State"].ToString();
            address.Pin = (int)updateString["Address"]["Pin"];
            string specificData = updateString["SpecificData"].ToString();

            staffOperator.UpdateStaff(id, name, phoneNumber, salary, address, specificData);
        }

        [HttpDelete]
        public void DeleteStaff(int id)
        {
            staffOperator.DeleteStaff(id);
        }

        [HttpDelete]
        public void DeleteMultipleStaff([FromUri] int[] ids)
        {
            foreach(int id in ids)
            {
                staffOperator.DeleteStaff(id);
            }
        }

    }
}
