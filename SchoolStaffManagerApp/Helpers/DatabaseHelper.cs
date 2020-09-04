using System;
using System.Collections.Generic;
using System.Data;
using StaffClassLibrary;


namespace SchoolStaffManagerApp
{
    public class DatabaseHelper
    {
        

        public static DataTable CollectBulkData()
        {
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

            InsertRow(dataTable);

            return dataTable;
        }

            
                   


        private static void InsertRow(DataTable dataTable)
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
                InsertRow(dataTable);
            }

        }

    }
}
