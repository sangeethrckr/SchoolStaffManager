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
        private InMemoryStaffOperator inMemoryStaffOperator = new InMemoryStaffOperator();

        private void Deserialize()
        {
            try
            {
                string json = File.ReadAllText(path);
                inMemoryStaffOperator.lstStaff = JsonConvert.DeserializeObject<List<Staff>>(json, settings);
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
                string newJsonResult = JsonConvert.SerializeObject(inMemoryStaffOperator.lstStaff, Formatting.Indented, settings);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void CreateStaff(StaffType staffType)
        {
            Deserialize();
            inMemoryStaffOperator.CreateStaff(staffType);
            Serialize();
        }
               
        public void GetAllStaffByStaffType(StaffType staffType)
        {
            Deserialize();
            inMemoryStaffOperator.GetAllStaffByStaffType(staffType);
        }

        public void GetStaffByStaffId(int staffId)
        {

            Deserialize();
            inMemoryStaffOperator.GetStaffByStaffId(staffId);
        }

        public void DeleteStaff(int staffId)
        {
            Deserialize();
            inMemoryStaffOperator.DeleteStaff(staffId);
            Serialize();
        }
        public void UpdateStaff(int staffId)
        {
            Deserialize();
            inMemoryStaffOperator.UpdateStaff(staffId);
            Serialize();
        }

       


    }
}
