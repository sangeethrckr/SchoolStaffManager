using System;
using System.Configuration;
using StaffClassLibrary;
using System.Data;
using System.Collections.Generic;


namespace SchoolStaffManagerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello {0}", ConfigurationManager.AppSettings.Get("SchoolName"));


            //string objectToInstantiate = ConfigurationManager.AppSettings.Get("staffStoreHandler");
            //var objectType = Type.GetType(objectToInstantiate);
            //IStaffOperator staffOperator = Activator.CreateInstance(objectType) as IStaffOperator;
            //ActionMenu(staffOperator);

            ActionMenu();


            Console.ReadKey();
        }

       
        private static void ActionMenu( )
        {

            int actionChoice;
            Staff staff;
            string result;
            Console.WriteLine("\nChoose Action\n1.Add Staff\n2.Bulk Insert\n3.View Staff Details\n4.View All Staff of type\n5.Update Staff Details\n6.Remove Staff\n7.Exit\n"); //Action Menu
            actionChoice = Convert.ToInt32(Console.ReadLine());

            switch (actionChoice)
            {
                case 1:
                    
                    result = DatabaseOperation.InsertStaff(StaffHelper.AddStaff(InputStaffProperties.AskStaffType()));
                    Console.WriteLine(result);
                    break;
                case 2:
                    DataTable dataTable = new DataTable("StaffTableType");
                    
                    dataTable.Columns.Add("StaffName", typeof(string));
                    dataTable.Columns.Add("PhoneNumber", typeof(string));
                    dataTable.Columns.Add("Salary", typeof(double));
                    dataTable.Columns.Add("HouseName", typeof(string));
                    dataTable.Columns.Add("City", typeof(string));
                    dataTable.Columns.Add("State", typeof(string));
                    dataTable.Columns.Add("PinCode", typeof(string));
                    dataTable.Columns.Add("StaffType", typeof(int));
                    dataTable.Columns.Add("SpecificData", typeof(string));
                    dataTable.Columns.Add("ClassAssigned", typeof(int));

                    CollectBulkData(dataTable);

                    result = DatabaseOperation.BulkInsertion(dataTable);
                    Console.WriteLine(result);
                    break;
                case 3:
                    staff = DatabaseOperation.GetStaffByStaffId(InputStaffProperties.AskStaffID());
                    if(staff != null)
                    {
                        StaffHelper.ViewDetails(staff);

                    }
                    else
                    {
                        Console.WriteLine("Staff not found!!\n");
                    }
                    break;
                case 4:
                    List<Staff> lstStaff = DatabaseOperation.GetAllStaffByType(InputStaffProperties.AskStaffType());
                    if (lstStaff != null)
                    {
                        foreach (Staff s in lstStaff)
                        {
                            StaffHelper.ViewDetails(s);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Staff not found!!\n");
                    }
                    
                    break;
                case 5:
                    
                    int staffID = InputStaffProperties.AskStaffID();
                    int st = DatabaseOperation.GetStaffType(staffID);
                    StaffType staffType;
                    if (st != 3)
                    {
                        staffType = (StaffType)st;
                    }
                    else
                    {
                        Console.WriteLine("Staff not found!\n");
                        break;
                    }
                    string name = InputStaffProperties.AskName();
                    string phoneNumber = InputStaffProperties.AskPhoneNumber();
                    double salary = InputStaffProperties.AskSalary();
                    Address address = InputStaffProperties.AskAddress();
                    string specificData;
                    
                    if (staffType == StaffType.teachingStaff)
                    {

                        specificData = InputStaffProperties.AskClass();
                    }
                    else
                    {
                        specificData = InputStaffProperties.AskPost();
                    }
                    result = DatabaseOperation.UpdateStaff(staffID,name,phoneNumber,salary,address,specificData);
                    Console.WriteLine(result);
                    break;
                case 6:

                    result = DatabaseOperation.RemoveStaff(InputStaffProperties.AskStaffID());
                    Console.WriteLine(result);
                    break;
                case 7:
                    System.Environment.Exit(0);
                    break;
                default:
                    break;
            }
            ActionMenu();

        }
        public static void CollectBulkData(DataTable dataTable)
        {
            
             
            DataRow dataRow = dataTable.NewRow();
            StaffType staffType = InputStaffProperties.AskStaffType();
            dataRow["StaffName"] = InputStaffProperties.AskName();
            dataRow["PhoneNumber"] = InputStaffProperties.AskPhoneNumber();
            dataRow["Salary"] = InputStaffProperties.AskSalary();
            Address address = InputStaffProperties.AskAddress();
            dataRow["HouseName"] = address.HouseName;
            dataRow["City"] = address.City;
            dataRow["State"] = address.State;
            dataRow["PinCode"] = address.Pin;
            dataRow["StaffType"] = (int)staffType;

            string specificData;
            int classAssigned = 0;
            if (staffType == StaffType.teachingStaff)
            {
                specificData = InputStaffProperties.AskSubject();
                classAssigned = Convert.ToInt32(InputStaffProperties.AskClass());
            }
            else
            {
                specificData = InputStaffProperties.AskPost();
            }

            dataRow["SpecificData"] = specificData;
            dataRow["ClassAssigned"] = classAssigned;

            dataTable.Rows.Add(dataRow);
            Console.WriteLine("\nInsertion Successfull\nDo you want to add more Staff?(y/n)\n");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'y')
            {
                CollectBulkData( dataTable);
            }

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