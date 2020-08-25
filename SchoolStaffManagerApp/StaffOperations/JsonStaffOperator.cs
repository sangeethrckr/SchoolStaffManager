using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



namespace SchoolStaffManagerApp
{
    class JsonStaffOperator : IStaffOperator
    {
        private string path = @"C:\Users\GS_Kira\source\repos\SchoolStaffManagerApp\SchoolStaffManagerApp\StaffOperations\staff.json";
        private JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        private List<Staff> staffList = new List<Staff>();

        private void Deserialize()
        {
            try
            {
                string json = File.ReadAllText(path);
                staffList = JsonConvert.DeserializeObject<List<Staff>>(json, settings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void Serialize()
        {
            try
            {
                string newJsonResult = JsonConvert.SerializeObject(staffList, Formatting.Indented, settings);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateStaff(StaffType staffType)
        {
            Staff staff = StaffHelper.AddStaff(staffType);
            Deserialize();
            staffList.Add(staff);
            Serialize();
        }
               
        public void GetAllStaffByStaffType(StaffType staffType)
        {
            Deserialize();

            foreach (Staff staff in staffList)
            {
                if (staff.StaffType == staffType)
                {
                    StaffHelper.ViewDetails(staff);
                }
            }
        }

        public void GetStaffByStaffId(int staffId)
        {

            Deserialize();

            foreach (Staff staff in staffList)
            {
                if (staff.StaffId == staffId)
                {
                    StaffHelper.ViewDetails(staff);
                    return;
                }
            }
            Console.WriteLine("Staff not found!\n");
        }

        public void DeleteStaff(int staffId)
        {
            Deserialize();

            foreach (Staff staff in staffList)
            {
                if (staff.StaffId == staffId)
                {
                    staffList.Remove(staff);

                    Serialize();

                    Console.WriteLine("Staff  Removed!\n");
                    return;
                }
            }
            Console.WriteLine("Staff not found!\n");
        }
        public void UpdateStaff(int staffId)
        {
            Deserialize();

            foreach (Staff staff in staffList)
            {
                if (staff.StaffId == staffId)
                {
                    StaffHelper.Update(staff);

                    Serialize();

                    Console.WriteLine("Staff  Updated!\n");
                    return;
                }
            }
            Console.WriteLine("Staff not found!\n");
        }

       


    }
}
