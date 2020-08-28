using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using StaffClassLibrary;



namespace SchoolStaffManagerApp
{
    class JsonStaffOperator : InMemoryStaffOperator,IStaffOperator
    {
        static string workingDirectory = Environment.CurrentDirectory;
        static string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        private string path = projectDirectory + ConfigurationManager.AppSettings.Get("jsonPath");

        private JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
        

        public JsonStaffOperator()
        {
            Deserialize();
        }

        ~JsonStaffOperator()
        {
            Serialize();
        }
        private void Deserialize()
        {
            try
            {
                string json = File.ReadAllText(path);
                lstStaff = JsonConvert.DeserializeObject<List<Staff>>(json,settings);
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
                string newJsonResult = JsonConvert.SerializeObject(lstStaff, Formatting.Indented, settings);
                File.WriteAllText(path, newJsonResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        

       


    }
}
