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
        private InMemoryStaffOperator inMemoryStaffOperator = new InMemoryStaffOperator();
        private void Deserialize()
        {
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                inMemoryStaffOperator.lstStaff = (List<Staff>)serializer.Deserialize(myFileStream);
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
                serializer.Serialize(writer, inMemoryStaffOperator.lstStaff);
                writer.Close();
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
