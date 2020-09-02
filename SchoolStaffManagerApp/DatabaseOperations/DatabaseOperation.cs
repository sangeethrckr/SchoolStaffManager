using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    class DatabaseOperation
    {
        SqlConnection con;
        DataTable dataTable = new DataTable("StaffTableType");
        DataRow dataRow;

        public DatabaseOperation()
        {
            con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));

            try
            {
                
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
            }
            catch (Exception)
            { }

        }

        public void InsertBulkData()
        {
           
            dataRow = dataTable.NewRow();
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
            if(choice == 'y')
            {
                InsertBulkData();
            }

        }

        public void BulkInsertion()
        {
            try
            {
                con.Open();
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("Proc_Staff_BulkInsertion", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@staffTable", dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                con.Close();
                dataTable.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine("\nBulk insertion error : " + e);
            }
        }

        public void InsertStaff()
        {
            StaffType staffType = InputStaffProperties.AskStaffType();

            string name = InputStaffProperties.AskName();
            string phoneNumber = InputStaffProperties.AskPhoneNumber();
            double salary = InputStaffProperties.AskSalary();
            Address address = InputStaffProperties.AskAddress();

            
            string subject = null, post = null;
            int classAssigned = 0;
            if (staffType == StaffType.teachingStaff)
            {
                subject = InputStaffProperties.AskSubject();
                classAssigned = Convert.ToInt32(InputStaffProperties.AskClass());
            }
            else
            {
                post = InputStaffProperties.AskPost();
            }

            try
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_Insert", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", salary);
                sqlCommand.Parameters.AddWithValue("@HouseName", address.HouseName);
                sqlCommand.Parameters.AddWithValue("@City", address.City);
                sqlCommand.Parameters.AddWithValue("@State", address.State);
                sqlCommand.Parameters.AddWithValue("@PinCode", address.Pin);
                sqlCommand.Parameters.AddWithValue("@StaffType", (int)staffType);
                sqlCommand.Parameters.AddWithValue("@Subject", subject);
                sqlCommand.Parameters.AddWithValue("@Post", post);
                sqlCommand.Parameters.AddWithValue("@ClassAssigned", classAssigned);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           

        }

        public void GetAllStaffByType()
        {
            StaffType staffType = InputStaffProperties.AskStaffType();

            List<Staff> finalResult ;

            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_GetAllStaffByType", con);
                
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", staffType);

                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    finalResult = Populate(sqlDataReader);
                    foreach (Staff staff in finalResult)
                    {
                        StaffHelper.ViewDetails(staff);
                    }
                    
                }
                else
                {
                    Console.WriteLine("No staff found!!\n");
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }
            

        }


        public void GetStaffByStaffId()
        {
            int staffID = InputStaffProperties.AskStaffID();

            Staff staffFound ;

            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_GetStaffByStaffId", con);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffID);

                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    staffFound = Populate(sqlDataReader)[0];
                    StaffHelper.ViewDetails(staffFound);
                }
                else
                {
                    Console.WriteLine("No staff found!!\n");
                }

                sqlDataReader.Close();
                sqlCommand.Dispose();
                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }


        }


        public void UpdateStaff()
        {
            StaffType staffType = InputStaffProperties.AskStaffType();
            int staffID = InputStaffProperties.AskStaffID();

            string name = InputStaffProperties.AskName();
            string phoneNumber = InputStaffProperties.AskPhoneNumber();
            double salary = InputStaffProperties.AskSalary();
            Address address = InputStaffProperties.AskAddress();


            string post = null;
            int classAssigned = 0;
            if (staffType == StaffType.teachingStaff)
            {
                
                classAssigned = Convert.ToInt32(InputStaffProperties.AskClass());
            }
            else
            {
                post = InputStaffProperties.AskPost();
            }

            try
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_UpdateStaff", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffID);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", salary);
                sqlCommand.Parameters.AddWithValue("@HouseName", address.HouseName);
                sqlCommand.Parameters.AddWithValue("@City", address.City);
                sqlCommand.Parameters.AddWithValue("@State", address.State);
                sqlCommand.Parameters.AddWithValue("@PinCode", address.Pin);
                sqlCommand.Parameters.AddWithValue("@Post", post);
                sqlCommand.Parameters.AddWithValue("@ClassAssigned", classAssigned);

                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Staff updated!!\n");
                }
                else
                {
                    Console.WriteLine("No staff found!!\n");
                }

                sqlCommand.Dispose();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void RemoveStaff()
        {
            int staffID = InputStaffProperties.AskStaffID();
                        

            try
            {
                con.Open();

                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_RemoveStaff", con);

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffID);

                if (sqlCommand.ExecuteNonQuery() == 1)
                {
                    Console.WriteLine("Staff removed!!\n");
                }
                else
                {
                    Console.WriteLine("No staff found!!\n");
                }

                sqlCommand.Dispose();
                con.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
            }


        }

        public List<Staff> Populate(SqlDataReader sqlDataReader)
        {
            List<Staff> staffList = new List<Staff>();
            while (sqlDataReader.Read())
            {
                StaffType staffType = (StaffType)Enum.ToObject(typeof(StaffType), sqlDataReader.GetValue(12));
                

                switch (staffType)
                {
                    case StaffType.teachingStaff:
                        TeachingStaff tStaff = new TeachingStaff();
                        tStaff.StaffId = Convert.ToInt32(sqlDataReader.GetValue(0));
                        tStaff.Name = sqlDataReader.GetValue(1).ToString();
                        tStaff.PhoneNumber = sqlDataReader.GetValue(2).ToString();
                        tStaff.Salary = Convert.ToInt64(sqlDataReader.GetValue(3));
                        tStaff.Address.HouseName = sqlDataReader.GetValue(4).ToString();
                        tStaff.Address.City = sqlDataReader.GetValue(5).ToString();
                        tStaff.Address.State = sqlDataReader.GetValue(6).ToString();
                        tStaff.Address.Pin = Convert.ToInt32(sqlDataReader.GetValue(7));
                        tStaff.Subject = sqlDataReader.GetValue(8).ToString();
                        tStaff.AssignedClass = sqlDataReader.GetValue(9).ToString();
                        staffList.Add(tStaff);
                        break;
                    case StaffType.administrativeStaff:
                        AdminstrativeStaff aStaff = new AdminstrativeStaff();
                        aStaff.StaffId = Convert.ToInt32(sqlDataReader.GetValue(0));
                        aStaff.Name = sqlDataReader.GetValue(1).ToString();
                        aStaff.PhoneNumber = sqlDataReader.GetValue(2).ToString();
                        aStaff.Salary = Convert.ToInt64(sqlDataReader.GetValue(3));
                        aStaff.Address.HouseName = sqlDataReader.GetValue(4).ToString();
                        aStaff.Address.City = sqlDataReader.GetValue(5).ToString();
                        aStaff.Address.State = sqlDataReader.GetValue(6).ToString();
                        aStaff.Address.Pin = Convert.ToInt32(sqlDataReader.GetValue(7));
                        aStaff.Post = sqlDataReader.GetValue(10).ToString();
                        staffList.Add(aStaff);

                        break;
                    case StaffType.supportStaff:
                        SupportStaff sStaff = new SupportStaff();
                        sStaff.StaffId = Convert.ToInt32(sqlDataReader.GetValue(0));
                        sStaff.Name = sqlDataReader.GetValue(1).ToString();
                        sStaff.PhoneNumber = sqlDataReader.GetValue(2).ToString();
                        sStaff.Salary = Convert.ToInt64(sqlDataReader.GetValue(3));
                        sStaff.Address.HouseName = sqlDataReader.GetValue(4).ToString();
                        sStaff.Address.City = sqlDataReader.GetValue(5).ToString();
                        sStaff.Address.State = sqlDataReader.GetValue(6).ToString();
                        sStaff.Address.Pin = Convert.ToInt32(sqlDataReader.GetValue(7));
                        sStaff.Post = sqlDataReader.GetValue(11).ToString();
                        staffList.Add(sStaff);

                        break;
                   
                }


            }
            return staffList;
        }



    }
}
