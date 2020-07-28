using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace SchoolStaffManagerApp
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            //string schoolName = ConfigurationManager.AppSettings.Get("SchoolName");
            //Console.WriteLine("Hello {0}\n", schoolName);
            StaffMenu();
        }

        private static void StaffMenu()
        {
            Console.WriteLine("Choose Staff Type in {0}\n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n", ConfigurationManager.AppSettings.Get("SchoolName"));   //Staff Menu
            int staffTypeChoice = Convert.ToInt32(Console.ReadLine());
            switch (staffTypeChoice)
            {
                case 1:
                    TeachingStaff teachingStaff = new TeachingStaff();
                    ActionMenu(teachingStaff);
                    break;
                case 2:
                    AdminstrativeStaff adminstrativeStaff = new AdminstrativeStaff();
                    ActionMenu(adminstrativeStaff);
                    break;
                case 3:
                    SupportStaff supportStaff = new SupportStaff();
                    ActionMenu(supportStaff);
                    break;
                default:
                    break;
            }
        }

        private static void ActionMenu(Staff staff)
        {

            while(true)
            {
                int actionChoice;
                Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.Update Staff Details\n4.Exit\n"); //Action Menu
                actionChoice = Convert.ToInt32(Console.ReadLine());
                switch (actionChoice)
                {
                    case 1:
                        staff.AddStaff();
                        break;
                    case 2:
                        staff.ViewDetails();
                        break;
                    case 3:
                        staff.Update();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                               
            } 
        }
    }
}