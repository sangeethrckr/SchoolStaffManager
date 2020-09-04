using System;
using System.Configuration;
using StaffClassLibrary;
using System.Collections.Generic;


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


            Console.ReadKey();
        }


       


        private static void ActionMenu(IStaffOperator staffOperator)
        {

            int actionChoice;
            StaffType staffType;
            int staffId;
            

            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.View Staff Details\n3.View All Staff of type\n4.Update Staff Details\n5.Remove Staff\n6.Bulk Insertion(For DB only)\n7.Exit\n"); //Action Menu
            actionChoice = Convert.ToInt32(Console.ReadLine());

            switch (actionChoice)
            {
                case 1:
                    Staff newStaff = StaffHelper.CreateStaff(InputStaffProperties.AskStaffType());
                    staffOperator.InsertStaff(newStaff);

                    break;
                case 2:
                    staffId = InputStaffProperties.AskStaffID();
                    var staff = staffOperator.GetStaffByStaffId(staffId);
                    if(staff != null)
                    {
                        StaffHelper.ViewDetails(staff);
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found!!");
                    }
                    
                    break;
                case 3:
                    staffType = InputStaffProperties.AskStaffType();
                    List<Staff> lstStaff =  staffOperator.GetAllStaffByStaffType(staffType);
                    if(lstStaff != null)
                    {
                        foreach (Staff _staff in lstStaff)
                        {
                            StaffHelper.ViewDetails(_staff);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nNo staff of type {0}!!",staffType);
                    }

                    
                    break;
                case 4:
                    staffId = InputStaffProperties.AskStaffID();
                    string staffName = InputStaffProperties.AskName();
                    string phoneNumber = InputStaffProperties.AskPhoneNumber();
                    double salary = InputStaffProperties.AskSalary();
                    Address address = InputStaffProperties.AskAddress();
                    StaffType? staffTypeNew = staffOperator.FindStaffType(staffId);
                    string specificData;
                    if(staffTypeNew == StaffType.teachingStaff)
                    {
                        specificData = InputStaffProperties.AskClass();
                    }
                    else
                    {
                        specificData = InputStaffProperties.AskPost();
                    }
                    if (staffOperator.UpdateStaff(staffId, staffName, phoneNumber, salary, address, specificData))
                    {
                        Console.WriteLine("\nStaff {0} updated",staffId);
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found!!");
                    }
                    break;
                case 5:
                    staffId = InputStaffProperties.AskStaffID();
                    if (staffOperator.DeleteStaff(staffId))
                    {
                        Console.WriteLine("\nStaff {0} removed",staffId);
                    }
                    else
                    {
                        Console.WriteLine("\nStaff not found!!");
                    }
                    
                    break;
                case 6:
                    Type type = staffOperator.GetType();
                    if (type.Equals(typeof(DatabaseStaffOperator)))
                    {
                        DatabaseStaffOperator dbStaffOperator = (DatabaseStaffOperator)staffOperator;
                        if (dbStaffOperator.BulkInsertion(DatabaseHelper.CollectBulkData()))
                        {
                            Console.WriteLine("\nBulk inserion succesful!!");
                        }
                        else
                        {
                            Console.WriteLine("\nBulk insertion failed");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nBulk insertion can only be perfomed on Database");
                    }
                    break;

                case 7:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            ActionMenu(staffOperator);

        }

    }


}