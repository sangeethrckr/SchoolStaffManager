using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace SchoolStaffManagerApp
{
    class JsonStaffOperator : IStaffOperator
    {
        public string path = @"C:\Users\GS_Kira\source\repos\SchoolStaffManagerApp\SchoolStaffManagerApp\StaffOperations\staff.json";
        

        

        public void CreateStaff(StaffType staffType)
        {
            Staff staff = StaffHelper.AddStaff(staffType);
            try
            {

                string json = File.ReadAllText(path);
                JObject jsonObject = JObject.Parse(json);
                JObject newStaff = JObject.FromObject(staff);
                
                JArray staffArray = (JArray)jsonObject["Staff"][staffType.ToString()];
                staffArray.Add(newStaff);
                jsonObject["Staff"][staffType.ToString()] = staffArray;

                string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
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
                JObject jsonObject = JObject.Parse(json);
                string staffArray = jsonObject["Staff"][staffType.ToString()].ToString();
                switch (staffType)
                {
                    case StaffType.teachingStaff:
                        List<TeachingStaff> teachingStafflist = JsonConvert.DeserializeObject<List<TeachingStaff>>(staffArray);
                        foreach (Staff staff in teachingStafflist)
                        {
                            StaffHelper.ViewDetails(staff);
                        }
                        break;
                    case StaffType.administrativeStaff:
                        List<AdminstrativeStaff> adminStafflist = JsonConvert.DeserializeObject<List<AdminstrativeStaff>>(staffArray);
                        foreach (Staff staff in adminStafflist)
                        {
                            StaffHelper.ViewDetails(staff);
                        }
                        break;
                    case StaffType.supportStaff:
                        List<SupportStaff> supportStaffList = JsonConvert.DeserializeObject<List<SupportStaff>>(staffArray);
                        foreach (Staff staff in supportStaffList)
                        {
                            StaffHelper.ViewDetails(staff);
                        }
                        break;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine( e);
            }
        }

        public void GetStaffByStaffId(int staffId)
        {
            string json = File.ReadAllText(path);
            JObject jsonObject = JObject.Parse(json);
            string staffArray = jsonObject["Staff"]["teachingStaff"].ToString();
            List<TeachingStaff> teachingStafflist = JsonConvert.DeserializeObject<List<TeachingStaff>>(staffArray);
            foreach (Staff staff in teachingStafflist)
            {
                if (staff.StaffId == staffId)
                {
                    StaffHelper.ViewDetails(staff);
                    return;
                }
            }
            staffArray = jsonObject["Staff"]["administrativeStaff"].ToString();
            List<AdminstrativeStaff> adminStafflist = JsonConvert.DeserializeObject<List<AdminstrativeStaff>>(staffArray);
            foreach (Staff staff in adminStafflist)
            {
                if (staff.StaffId == staffId)
                {
                    StaffHelper.ViewDetails(staff);
                    return;
                }
            }
            staffArray = jsonObject["Staff"]["supportStaff"].ToString();
            List<SupportStaff> supportStaffList = JsonConvert.DeserializeObject<List<SupportStaff>>(staffArray);
            foreach (Staff staff in supportStaffList)
            {
                if (staff.StaffId == staffId)
                {
                    StaffHelper.ViewDetails(staff);
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found!");
        }

        public void DeleteStaff(int staffId)
        {
            string json = File.ReadAllText(path);
            JObject jsonObject = JObject.Parse(json);
            JArray teacherJArray = (JArray)jsonObject["Staff"]["teachingStaff"];
            foreach(JObject staff in teacherJArray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    teacherJArray.Remove(staff);
                    jsonObject["Staff"]["teachingStaff"] = teacherJArray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Removed\n");
                    return;
                }
            }
            JArray adminJarray = (JArray)jsonObject["Staff"]["administrativeStaff"];
            foreach (JObject staff in adminJarray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    adminJarray.Remove(staff);
                    jsonObject["Staff"]["administrativeStaff"] = adminJarray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Removed\n");
                    return;
                }
            }
            JArray supportJArray = (JArray)jsonObject["Staff"]["supportStaff"];
            foreach (JObject staff in supportJArray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    supportJArray.Remove(staff);
                    jsonObject["Staff"]["supportStaff"] = supportJArray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Removed\n");
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found!");


        }
        public void UpdateStaff(int staffId)
        {
            string json = File.ReadAllText(path);
            JObject jsonObject = JObject.Parse(json);
            JArray teacherJArray = (JArray)jsonObject["Staff"]["teachingStaff"];
            foreach (JObject staff in teacherJArray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    teacherJArray.Remove(staff);
                    JObject updatedStaff = Update(staffId,StaffType.teachingStaff);
                    teacherJArray.Add(updatedStaff);
                    jsonObject["Staff"]["teachingStaff"] = teacherJArray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Updated\n");
                    return;
                }
            }
            JArray adminJarray = (JArray)jsonObject["Staff"]["administrativeStaff"];
            foreach (JObject staff in adminJarray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    adminJarray.Remove(staff);
                    JObject updatedStaff = Update(staffId, StaffType.administrativeStaff);
                    adminJarray.Add(updatedStaff);
                    jsonObject["Staff"]["administrativeStaff"] = adminJarray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Updated\n");
                    return;
                }
            }
            JArray supportJArray = (JArray)jsonObject["Staff"]["supportStaff"];
            foreach (JObject staff in supportJArray)
            {
                if (staff["StaffId"].ToString() == staffId.ToString())
                {
                    supportJArray.Remove(staff);
                    JObject updatedStaff = Update(staffId, StaffType.supportStaff);
                    supportJArray.Add(updatedStaff);
                    jsonObject["Staff"]["supportStaff"] = supportJArray;
                    string newJsonResult = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
                    File.WriteAllText(path, newJsonResult);
                    Console.WriteLine("Staff Updated\n");
                    return;
                }
            }
            Console.WriteLine("\nStaff Not Found!");
        }

        private JObject Update(int staffId,StaffType staffType)
        {
            string json = File.ReadAllText(path);
            JObject jsonObject = JObject.Parse(json);
            string staffArray = jsonObject["Staff"][staffType.ToString()].ToString();
            switch (staffType)
            {
                case StaffType.teachingStaff:
                    List<TeachingStaff> teachingStafflist = JsonConvert.DeserializeObject<List<TeachingStaff>>(staffArray);
                    foreach (Staff staff in teachingStafflist)
                    {
                        if (staff.StaffId == staffId)
                        {
                            StaffHelper.Update(staff);
                            return JObject.FromObject(staff);
                        }
                    }
                    break;
                case StaffType.administrativeStaff:
                    List<AdminstrativeStaff> adminStaffList = JsonConvert.DeserializeObject<List<AdminstrativeStaff>>(staffArray);
                    foreach (Staff staff in adminStaffList)
                    {
                        if (staff.StaffId == staffId)
                        {
                            StaffHelper.Update(staff);
                            return JObject.FromObject(staff);
                        }
                    }
                    break;
                case StaffType.supportStaff:
                    List<SupportStaff> supportStaffList = JsonConvert.DeserializeObject<List<SupportStaff>>(staffArray);
                    foreach (Staff staff in supportStaffList)
                    {
                        if (staff.StaffId == staffId)
                        {
                            StaffHelper.Update(staff);
                            return JObject.FromObject(staff);
                        }
                    }
                    break;
            }
            
            return null;
        }


    }
}
