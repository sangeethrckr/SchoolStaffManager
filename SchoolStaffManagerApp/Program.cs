using System;
using System.Configuration;
using StaffClassLibrary;


namespace SchoolStaffManagerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello {0}", ConfigurationManager.AppSettings.Get("SchoolName"));
            string objectToInstantiate = ConfigurationManager.AppSettings.Get("staffStoreHandler");
            var objectType = Type.GetType(objectToInstantiate);
            IStaffOperator staffOperator = Activator.CreateInstance(objectType) as IStaffOperator;
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
                    staffType = InputStaffProperties.AskStaffType();
                    staffOperator.CreateStaff(staffType);
                                                
                    break;
                case 2:
                    staffId = InputStaffProperties.AskStaffID();
                    staffOperator.GetStaffByStaffId(staffId);
                    break;
                case 3:
                    staffType = InputStaffProperties.AskStaffType();
                    staffOperator.GetAllStaffByStaffType(staffType);
                    break;
                case 4:
                    staffId = InputStaffProperties.AskStaffID();
                    staffOperator.UpdateStaff(staffId);
                    break;
                case 5:
                    staffId = InputStaffProperties.AskStaffID();
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

    }

    
}