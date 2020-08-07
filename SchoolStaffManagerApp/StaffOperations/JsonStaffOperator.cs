using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace SchoolStaffManagerApp
{
    class JsonStaffOperator : IStaffOperator
    {
        public string path = @"C:\Users\GS_Kira\source\repos\SchoolStaffManagerApp\SchoolStaffManagerApp\StaffOperations\staff.json";
        private string jsonString;

        

        public void CreateStaff(StaffType staffType)
        {
            
            switch (staffType)
            {
                case StaffType.teachingStaff:
                    TeachingStaff teachingStaff = TeachingStaffHelper.AddStaff();

                    jsonString = JsonSerializer.Serialize(teachingStaff);
                    break;
                case StaffType.administrativeStaff:
                    AdminstrativeStaff adminStaff = AdministrativeStaffHelper.AddStaff();
                    jsonString = JsonSerializer.Serialize(adminStaff);
                    break;
                case StaffType.supportStaff:
                    SupportStaff supportStaff = SupportStaffHelper.AddStaff();
                    jsonString = JsonSerializer.Serialize(supportStaff);
                    break;
                default:
                    jsonString = "Error";
                    break;
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(jsonString.ToString());
                sw.Close();
            }

        }

        

        public void GetAllStaffByStaffType(StaffType staffType)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                Staff staff;
                while ((line = sr.ReadLine()) != null)
                {

                    staff = JsonSerializer.Deserialize<Staff>(line);

                    if (staff.StaffType == staffType)
                    {

                        switch (staff.StaffType)
                        {
                            case StaffType.teachingStaff:
                                TeachingStaff teachingStaff = JsonSerializer.Deserialize<TeachingStaff>(line);
                                StaffHelper.ViewDetails(teachingStaff);
                                break;
                            case StaffType.administrativeStaff:
                                AdminstrativeStaff adminStaff = JsonSerializer.Deserialize<AdminstrativeStaff>(line);
                                StaffHelper.ViewDetails(adminStaff);
                                break;
                            case StaffType.supportStaff:
                                SupportStaff supportStaff = JsonSerializer.Deserialize<SupportStaff>(line);
                                StaffHelper.ViewDetails(supportStaff);
                                break;
                            default:
                                break;
                        }
                    }

                }
                //Console.WriteLine("\nStaff not found");

            }
        }

        public void GetStaffByStaffId(int staffId)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                Staff staff;
                while ((line = sr.ReadLine()) != null)
                {

                    staff = JsonSerializer.Deserialize<Staff>(line);

                    if (staff.StaffId == staffId)
                    {

                        switch (staff.StaffType)
                        {
                            case StaffType.teachingStaff:
                                TeachingStaff teachingStaff = JsonSerializer.Deserialize<TeachingStaff>(line);
                                StaffHelper.ViewDetails(teachingStaff);
                                break;
                            case StaffType.administrativeStaff:
                                AdminstrativeStaff adminStaff = JsonSerializer.Deserialize<AdminstrativeStaff>(line);
                                StaffHelper.ViewDetails(adminStaff);
                                break;
                            case StaffType.supportStaff:
                                SupportStaff supportStaff = JsonSerializer.Deserialize<SupportStaff>(line);
                                StaffHelper.ViewDetails(supportStaff);
                                break;
                            default:
                                break;
                        }
                    }

                }
                //Console.WriteLine("\nStaff not found");
                
            }
        }

        public void DeleteStaff(int staffId)
        {
            string tempFile = Path.GetTempFileName();
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamWriter sw = new StreamWriter(tempFile))
                {
                    string line;
                    Staff staff;
                    while ((line = sr.ReadLine()) != null)
                    {

                        staff = JsonSerializer.Deserialize<Staff>(line);

                        if (staff.StaffId != staffId)
                        {
                            sw.WriteLine(line);

                        }

                    }
                }
            }
            File.Delete(path);
            File.Move(tempFile, path);
        }
        public void UpdateStaff(int staffId)
        {
            string tempFile = Path.GetTempFileName();
            using (StreamReader sr = new StreamReader(path))
            {
                using (StreamWriter sw = new StreamWriter(tempFile))
                {
                    string line;
                    Staff staff;
                    while ((line = sr.ReadLine()) != null)
                    {

                        staff = JsonSerializer.Deserialize<Staff>(line);

                        if (staff.StaffId != staffId)
                        {
                            sw.WriteLine(line);

                        }
                        else
                        {
                            switch (staff.StaffType)
                            {
                                case StaffType.teachingStaff:
                                    TeachingStaff teachingStaff = JsonSerializer.Deserialize<TeachingStaff>(line);
                                    StaffHelper.Update(teachingStaff);
                                    jsonString = JsonSerializer.Serialize(teachingStaff);
                                    break;
                                case StaffType.administrativeStaff:
                                    AdminstrativeStaff adminStaff = JsonSerializer.Deserialize<AdminstrativeStaff>(line);
                                    StaffHelper.Update(adminStaff);
                                    jsonString = JsonSerializer.Serialize(adminStaff);
                                    break;
                                case StaffType.supportStaff:
                                    SupportStaff supportStaff = JsonSerializer.Deserialize<SupportStaff>(line);
                                    StaffHelper.Update(supportStaff);
                                    jsonString = JsonSerializer.Serialize(supportStaff);
                                    break;
                                default:
                                    break;
                            }
                            sw.WriteLine(jsonString.ToString());
                        }

                    }
                }
            }
            File.Delete(path);
            File.Move(tempFile, path);
        }

        

    }
}
