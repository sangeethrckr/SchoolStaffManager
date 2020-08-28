using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Configuration;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    class XmlStaffOperator : InMemoryStaffOperator,IStaffOperator
    {

        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        private string path = projectDirectory + ConfigurationManager.AppSettings.Get("xmlPath");

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
                Console.WriteLine(e);
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
                Console.WriteLine(e);
            }
        }

        
    }
}
