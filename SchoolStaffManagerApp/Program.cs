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
            
            StaffMenu();

        }

        private static void StaffMenu()
        {
            Console.WriteLine("Choose Staff Type in {0}\n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n", ConfigurationManager.AppSettings.Get("SchoolName"));   //Staff Menu
            int staffTypeChoice = Convert.ToInt32(Console.ReadLine());
            List<Staff> lstStaff = new List<Staff>();
            switch (staffTypeChoice)
            {
                case 1:
                    ActionMenu(lstStaff,StaffType.teachingStaff);
                    break;
                case 2:
                    ActionMenu(lstStaff,StaffType.administrativeStaff);
                    break;
                case 3:
                    ActionMenu(lstStaff,StaffType.supportStaff);
                    break;
                default:
                    break;
            }
        }

        private static void ActionMenu(List<Staff> lstStaff,StaffType staffType)
        {

            
            int actionChoice;
            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.View All Staff Details\n4.Update Staff Details\n5.Remove Staff\n6.Exit\n"); //Action Menu
            actionChoice = Convert.ToInt32(Console.ReadLine());
            int position;
            int staffId;
                
            switch (actionChoice)
            {
                case 1:
                    switch (staffType)
                    {
                        case StaffType.teachingStaff:
                            TeachingStaff newTeachingStaff = new TeachingStaff();
                            newTeachingStaff.AddStaff();
                            lstStaff.Add(newTeachingStaff);
                            break;
                        case StaffType.administrativeStaff:
                            AdminstrativeStaff newAdministrativeStaff = new AdminstrativeStaff();
                            newAdministrativeStaff.AddStaff();
                            lstStaff.Add(newAdministrativeStaff);
                            break;
                        case StaffType.supportStaff:
                            SupportStaff newSupportStaff = new SupportStaff();
                            newSupportStaff.AddStaff();
                            lstStaff.Add(newSupportStaff);
                            break;
                    }
                                                
                    break;
                case 2:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = lstStaff.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        lstStaff[position].ViewDetails();
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found");
                    }
                    break;
                case 3:
                    foreach(Staff staff in lstStaff)
                    {
                        staff.ViewDetails();
                    }
                    break;
                case 4:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = lstStaff.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        lstStaff[position].Update();
                        Console.WriteLine("\nStaff details updated");
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found");
                    }
                    break;
                case 5:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = lstStaff.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        lstStaff.RemoveAt(position);
                        Console.WriteLine("\nStaff ({0}) removed", staffId);
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found");
                    }
                    break;
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            ActionMenu(lstStaff, staffType);
                              
                      
            
        }
    }
}