using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Configuration;


namespace StaffClassLibrary
{
    public class XmlStaffOperator : InMemoryStaffOperator
    {

        
        private string path = ConfigurationManager.AppSettings.Get("xmlPath");

        private XmlSerializer serializer = new XmlSerializer(typeof(List<Staff>));
        

        public XmlStaffOperator()
        {
            Deserialize();
        }

        ~XmlStaffOperator()
        {
            Serialize();
        }

        private void Deserialize()
        {
            try
            {
                var myFileStream = new FileStream(path, FileMode.Open);
                lstStaff = (List<Staff>)serializer.Deserialize(myFileStream);
                myFileStream.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Serialize()
        {
            try
            {
                TextWriter writer = new StreamWriter(path);
                serializer.Serialize(writer, lstStaff);
                writer.Close();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
