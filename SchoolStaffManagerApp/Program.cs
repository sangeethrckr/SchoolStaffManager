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
                    List<Staff> teachingStaffs = new List<TeachingStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(teachingStaffs,1);
                    break;
                case 2:
                    List<Staff> administrativeStaffs = new List<AdminstrativeStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(administrativeStaffs,2);
                    break;
                case 3:
                    List<Staff> supportStaffs = new List<SupportStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(supportStaffs,3);
                    break;
                default:
                    break;
            }
        }

        private static void ActionMenu(List<Staff> staffs,int typeID)
        {

            while(true)
            {
                int actionChoice;
                Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.Update Staff Details\n4.Remove Staff\n5.Exit\n"); //Action Menu
                actionChoice = Convert.ToInt32(Console.ReadLine());
                int pos;
                string staffId;
                string predecessorStaffID;
                switch (actionChoice)
                {
                    case 1:
                        switch (typeID)
                        {
                            case 1:
                                staffs.Add(new TeachingStaff());
                                break;
                            case 2:
                                staffs.Add(new AdminstrativeStaff());
                                break;
                            case 3:
                                staffs.Add(new SupportStaff());
                                break;
                        }
                        
                        pos = staffs.Count;
                        if (pos - 2 != -1)
                        {
                            predecessorStaffID = staffs[pos - 2].staffID;
                        }
                        else
                        {
                            predecessorStaffID = null;
                        }
                        staffs[pos-1].AddStaff(predecessorStaffID);
                        break;
                    case 2:
                        Console.WriteLine("\nEnter Staff ID");
                        staffId = Console.ReadLine();
                        pos = staffs.FindIndex(x => x.staffID == staffId);
                        if (pos != -1)
                        {
                            staffs[pos].ViewDetails();
                        }
                        else
                        {
                            Console.WriteLine("\nStaff not found");
                        }
                        break;
                    case 3:
                        Console.WriteLine("\nEnter Staff ID");
                        staffId = Console.ReadLine();
                        pos = staffs.FindIndex(x => x.staffID == staffId);
                        if (pos != -1)
                        {
                            staffs[pos].Update();
                            Console.WriteLine("\nStaff details updated");
                        }
                        else
                        {
                            Console.WriteLine("\nStaff not found");
                        }
                        break;
                    case 4:
                        Console.WriteLine("\nEnter Staff ID");
                        staffId = Console.ReadLine();
                        pos = staffs.FindIndex(x => x.staffID == staffId);
                        if (pos != -1)
                        {
                            staffs.RemoveAt(pos);
                            Console.WriteLine("\nStaff ({0}) removed", staffId);
                        }
                        else
                        {
                            Console.WriteLine("\nStaff not found");
                        }
                        break;
                    case 5:
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                               
            }
            
            
        }
    }
}