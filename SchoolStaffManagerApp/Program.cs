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
            switch (staffTypeChoice)
            {
                case 1:
                    List<Staff> teachingStaffs = new List<TeachingStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(teachingStaffs,StaffType.teachingStaff);
                    break;
                case 2:
                    List<Staff> administrativeStaffs = new List<AdminstrativeStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(administrativeStaffs,StaffType.administrativeStaff);
                    break;
                case 3:
                    List<Staff> supportStaffs = new List<SupportStaff>().ConvertAll(x => (Staff)x);
                    ActionMenu(supportStaffs,StaffType.supportStaff);
                    break;
                default:
                    break;
            }
        }

        private static void ActionMenu(List<Staff> staffs,StaffType staffType)
        {

            
            int actionChoice;
            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.Update Staff Details\n4.Remove Staff\n5.Exit\n"); //Action Menu
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
                            staffs.Add(newTeachingStaff);
                            break;
                        case StaffType.administrativeStaff:
                            AdminstrativeStaff newAdministrativeStaff = new AdminstrativeStaff();
                            newAdministrativeStaff.AddStaff();
                            staffs.Add(newAdministrativeStaff);
                            break;
                        case StaffType.supportStaff:
                            SupportStaff newSupportStaff = new SupportStaff();
                            newSupportStaff.AddStaff();
                            staffs.Add(newSupportStaff);
                            break;
                    }
                                                
                    break;
                case 2:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = staffs.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        staffs[position].ViewDetails();
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found");
                    }
                    break;
                case 3:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = staffs.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        staffs[position].Update();
                        Console.WriteLine("\nStaff details updated");
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found");
                    }
                    break;
                case 4:
                    Console.WriteLine("\nEnter Staff ID");
                    staffId = Convert.ToInt32(Console.ReadLine());
                    position = staffs.FindIndex(x => x.staffId == staffId);
                    if (position != -1)
                    {
                        staffs.RemoveAt(position);
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
            ActionMenu(staffs, staffType);
                              
                      
            
        }
    }
}