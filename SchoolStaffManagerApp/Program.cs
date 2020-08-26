using System;
using System.Configuration;
using System.Reflection;

namespace SchoolStaffManagerApp
{
    public class Program
    {
        


        public static void Main(string[] args)
        {
            Console.WriteLine("Hello {0}", ConfigurationManager.AppSettings.Get("SchoolName"));
            IStaffOperator staffOperator = CreateInstance<IStaffOperator>();
            ActionMenu(staffOperator);

        }

       
        private static void ActionMenu(IStaffOperator staffOperator)
        {
                        
            int actionChoice;
            StaffType staffType;
            int staffId;

            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.View All Staff of type\n4.Update Staff Details\n5.Remove Staff\n6.Exit\n"); //Action Menu
            actionChoice = Convert.ToInt32(Console.ReadLine());
            
            switch (actionChoice)
            {
                case 1:
                    staffType = Validator.AskStaffType();
                    staffOperator.CreateStaff(staffType);
                                                
                    break;
                case 2:
                    staffId = Validator.AskStaffID();
                    staffOperator.GetStaffByStaffId(staffId);
                    break;
                case 3:
                    staffType = Validator.AskStaffType();
                    staffOperator.GetAllStaffByStaffType(staffType);
                    break;
                case 4:
                    staffId = Validator.AskStaffID();
                    staffOperator.UpdateStaff(staffId);
                    break;
                case 5:
                    staffId = Validator.AskStaffID();
                    staffOperator.DeleteStaff(staffId);
                    break;
                    
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            ActionMenu(staffOperator);      
           
        }


        public static I CreateInstance<I>() where I : class
        {
            string assemblyPath = Environment.CurrentDirectory + "\\SchoolStaffManagerApp.exe";

            Assembly assembly;

            assembly = Assembly.LoadFrom(assemblyPath);
            Type type;

            Console.WriteLine("\nChoose implementaion type\n1.json\n2.xml\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    type = assembly.GetType(ConfigurationManager.AppSettings.Get("jsonClass"));
                    break;
                case 2:
                    type = assembly.GetType(ConfigurationManager.AppSettings.Get("xmlClass"));
                    break;
                default:
                    Console.WriteLine("\nEnter correct option!!");
                    return CreateInstance<IStaffOperator>() as I;
            }

            return Activator.CreateInstance(type) as I;
        }
    }

    
}