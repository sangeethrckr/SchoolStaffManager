using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using StaffClassLibrary;



namespace StaffClassLibrary
{
    public class JsonStaffOperator : InMemoryStaffOperator
    {
        
        private string path = ConfigurationManager.AppSettings.Get("jsonPath");

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
                throw e;
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
                throw e;
            }
        }

        

       


    }
}
