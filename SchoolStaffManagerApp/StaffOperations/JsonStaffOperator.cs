using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;



namespace SchoolStaffManagerApp
{
    class JsonStaffOperator : IStaffOperator
    {
        private string path = @"C:\Users\GS_Kira\source\repos\SchoolStaffManagerApp\SchoolStaffManagerApp\StaffOperations\staff.json";
        private readonly JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };


        public void CreateStaff(StaffType staffType)
        {
            Staff staff = StaffHelper.AddStaff(staffType);
            try
            {
                string json = File.ReadAllText(path);
                
                List<Staff> Stafflist = JsonConvert.DeserializeObject<List<Staff>>(json,settings);
                Stafflist.Add(staff);

                string newJsonResult = JsonConvert.SerializeObject(Stafflist,Formatting.Indented, settings);
                File.WriteAllText(path, newJsonResult);

            }
            catch (Exception e)
            {
                Console.WriteLine("File addition error" + e);
            }

        }
               
        public void GetAllStaffByStaffType(StaffType staffType)
        {
            try
            {
                string json = File.ReadAllText(path);
                
                List<Staff> Stafflist = JsonConvert.DeserializeObject<List<Staff>>(json, settings);

                foreach(Staff staff in Stafflist)
                {
                    if(staff.StaffType == staffType)
                    {
                        StaffHelper.ViewDetails(staff);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine( e);
            }
        }

        public void GetStaffByStaffId(int staffId)
        {

            try
            {
                string json = File.ReadAllText(path);
                
                List<Staff> Stafflist = JsonConvert.DeserializeObject<List<Staff>>(json, settings);

                foreach (Staff staff in Stafflist)
                {
                    if (staff.StaffId == staffId)
                    {
                        StaffHelper.ViewDetails(staff);
                        return;
                    }
                }
                Console.WriteLine("Staff not found!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteStaff(int staffId)
        {
            try
            {
                string json = File.ReadAllText(path);
                
                List<Staff> Stafflist = JsonConvert.DeserializeObject<List<Staff>>(json, settings);

                foreach (Staff staff in Stafflist)
                {
                    if (staff.StaffId == staffId)
                    {
                        Stafflist.Remove(staff);


                        string newJsonResult = JsonConvert.SerializeObject(Stafflist, Formatting.Indented, settings);
                        File.WriteAllText(path, newJsonResult);

                        Console.WriteLine("Staff  Removed!\n");
                        return;
                    }
                }
                Console.WriteLine("Staff not found!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void UpdateStaff(int staffId)
        {
            try
            {
                string json = File.ReadAllText(path);


                List<Staff> Stafflist = JsonConvert.DeserializeObject<List<Staff>>(json, settings);

                foreach (Staff staff in Stafflist)
                {
                    if (staff.StaffId == staffId)
                    {
                        Stafflist.Remove(staff);
                        StaffHelper.Update(staff);
                        Stafflist.Add(staff);

                        string newJsonResult = JsonConvert.SerializeObject(Stafflist, Formatting.Indented, settings);
                        File.WriteAllText(path, newJsonResult);

                        Console.WriteLine("Staff  Updated!\n");
                        return;
                    }
                }
                Console.WriteLine("Staff not found!\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

       


    }
}
