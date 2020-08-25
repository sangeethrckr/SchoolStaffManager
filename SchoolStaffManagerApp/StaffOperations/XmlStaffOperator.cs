using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization; 

namespace SchoolStaffManagerApp
{
    class XmlStaffOperator :  IStaffOperator
    {

        private string path = @"C:\Users\GS_Kira\source\repos\SchoolStaffManagerApp\SchoolStaffManagerApp\StaffOperations\staff.xml";
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Staff>));


        public void CreateStaff(StaffType staffType)
        {
            Staff staff = StaffHelper.AddStaff(staffType);
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                List<Staff> staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
                staffList.Add(staff);

                TextWriter writer = new StreamWriter(path);
                serializer.Serialize(writer, staffList);
                writer.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine( e);
            }

        }

        public void GetAllStaffByStaffType(StaffType staffType)
        {
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                List<Staff> staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
                foreach (Staff staff in staffList)
                {
                    if (staff.StaffType == staffType)
                    {
                        StaffHelper.ViewDetails(staff);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void GetStaffByStaffId(int staffId)
        {

            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                List<Staff> staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
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
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteStaff(int staffId)
        {
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                List<Staff> staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
                foreach (Staff staff in staffList)
                {
                    if (staff.StaffId == staffId)
                    {
                        staffList.Remove(staff);


                        TextWriter writer = new StreamWriter(path);
                        serializer.Serialize(writer, staffList);
                        writer.Close();

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
                var myFileStream = new FileStream(path, FileMode.Open);
                List<Staff> staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
                foreach (Staff staff in staffList)
                {
                    if (staff.StaffId == staffId)
                    {
                        staffList.Remove(staff);
                        StaffHelper.Update(staff);
                        staffList.Add(staff);

                        TextWriter writer = new StreamWriter(path);
                        serializer.Serialize(writer, staffList);
                        writer.Close();

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
