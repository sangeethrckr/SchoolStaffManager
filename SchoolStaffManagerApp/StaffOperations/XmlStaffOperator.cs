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
        private List<Staff> staffList = new List<Staff>();

        private void Deserialize()
        {
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                staffList = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
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
                TextWriter writer = new StreamWriter(path);
                serializer.Serialize(writer, staffList);
                writer.Close();
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
