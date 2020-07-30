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
            List<Staff> lstStaff = new List<Staff>();
            //StaffMenu(lstStaff);
            ActionMenu(lstStaff);

        }

       
        private static void ActionMenu(List<Staff> lstStaff)
        {
                        
            int actionChoice;
            Staff staffFound;

            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.View All Staff Details\n4.Update Staff Details\n5.Remove Staff\n6.Exit\n"); //Action Menu
            actionChoice = Convert.ToInt32(Console.ReadLine());
            
            switch (actionChoice)
            {
                case 1:
                    StaffType staffType = StaffMenu();
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
                    staffFound = FindStaff(lstStaff);
                    if(staffFound != null)
                    {
                        staffFound.ViewDetails();
                    }
                    break;
                case 3:
                    if(lstStaff.Count == 0)
                    {
                        Console.WriteLine("\nNo staff found");
                        break;
                    }
                    foreach(Staff staff in lstStaff)
                    {
                        staff.ViewDetails();
                        
                    }
                    break;
                case 4:
                    staffFound = FindStaff(lstStaff);
                    if (staffFound != null)
                    {
                        staffFound.Update();
                        Console.WriteLine("\nStaff details updated");
                    }
                    break;
                case 5:
                    staffFound = FindStaff(lstStaff);
                    if (staffFound != null)
                    {
                        lstStaff.Remove(staffFound);
                        Console.WriteLine("\nStaff removed!!");
                    }
                    break;
                case 6:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            ActionMenu(lstStaff);
                             
                    
           
        }

        private static StaffType StaffMenu()
        {
            Console.WriteLine("\nChoose Staff Type in {0}\n1.Teaching Staff\n2.Admninistrative Staff\n3.Support Staff\n", ConfigurationManager.AppSettings.Get("SchoolName"));   //Staff Menu
            int staffTypeChoice = Convert.ToInt32(Console.ReadLine());

            switch (staffTypeChoice)
            {
                case 1:
                    return StaffType.teachingStaff;

                case 2:
                    return StaffType.administrativeStaff;

                case 3:
                    return StaffType.supportStaff;

                default:
                    Console.WriteLine("\nIncorrect Option");
                    return StaffMenu();
            }
        }

        private static Staff FindStaff(List<Staff> lstStaff)
        {
            Console.WriteLine("\nEnter Staff ID");
            int staffId = Convert.ToInt32(Console.ReadLine());
            
            foreach (Staff staff in lstStaff)
            {
                if (staff.staffId == staffId)
                {
                    return staff;
                    
                }
            }
            Console.WriteLine("\nStaff not found");
            return null;

        }
    }
}