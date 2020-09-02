using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using StaffClassLibrary;

namespace SchoolStaffManagerApp
{
    public static class DatabaseOperation
    {
       
        public static string BulkInsertion(DataTable dataTable)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            try
            {
                con.Open();
                SqlCommand sqlCommand;
                sqlCommand = new SqlCommand("Proc_Staff_BulkInsertion", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@staffTable", dataTable);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                dataTable.Clear();
                return "Bulk insertion succesful";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                con.Close();

            }
        }

        public static string InsertStaff(Staff staff)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));

            string subject = null, post = null;
            int classAssigned = 0;

            switch (staff.StaffType)
            {
                case StaffType.teachingStaff:
                    TeachingStaff tStaff = (TeachingStaff)staff;
                    subject = tStaff.Subject;
                    classAssigned = Convert.ToInt32(tStaff.AssignedClass);
                    break;
                case StaffType.administrativeStaff:
                    AdminstrativeStaff aStaff = (AdminstrativeStaff)staff;
                    post = aStaff.Post;
                    break;
                case StaffType.supportStaff:
                    SupportStaff sStaff = (SupportStaff)staff;
                    post = sStaff.Post;
                    break;
            }


            try
            {
                con.Open();
                SqlCommand sqlCommand = new SqlCommand("Proc_Staff_Insert", con);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Name", staff.Name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", staff.PhoneNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", staff.Salary);
                sqlCommand.Parameters.AddWithValue("@HouseName", staff.Address.HouseName);
                sqlCommand.Parameters.AddWithValue("@City", staff.Address.City);
                sqlCommand.Parameters.AddWithValue("@State", staff.Address.State);
                sqlCommand.Parameters.AddWithValue("@PinCode", staff.Address.Pin);
                sqlCommand.Parameters.AddWithValue("@StaffType", (int)staff.StaffType);
                sqlCommand.Parameters.AddWithValue("@Subject", subject);
                sqlCommand.Parameters.AddWithValue("@Post", post);
                sqlCommand.Parameters.AddWithValue("@ClassAssigned", classAssigned);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                return "Staff insertion Succesful";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                con.Close();
            }

        }

        public static List<Staff> GetAllStaffByType(StaffType staffType)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            List<Staff> finalResult ;
            SqlCommand sqlCommand = new SqlCommand("Proc_Staff_GetAllStaffByType", con);
            

            try
            {
                con.Open();              
                
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffType", staffType);
                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();
               
                if (sqlDataReader.HasRows)
                {

                    finalResult = Populate(sqlDataReader);
                    sqlDataReader.Close();
                    return finalResult;
                    
                }
                else
                {
                    sqlDataReader.Close();
                    return null;
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
                return null;
            }

            finally
            {
                
                sqlCommand.Dispose();
                con.Close();
            }

        }


        public static Staff GetStaffByStaffId(int staffId)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            Staff staffFound ;
            SqlCommand sqlCommand = new SqlCommand("Proc_Staff_GetStaffByStaffId", con);

            try
            {
                con.Open();

                

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffId);

                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {

                    staffFound = Populate(sqlDataReader)[0];
                    sqlDataReader.Close();
                    return staffFound;
                }
                else
                {
                    sqlDataReader.Close();
                    return null;
                }

                
                

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
                return null;
            }

            finally
            {
                sqlCommand.Dispose();
                con.Close();
            }


        }


        public static string UpdateStaff(int staffID, string name, string phoneNumber, double salary, Address address,string specificData)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand sqlCommand = new SqlCommand("Proc_Staff_UpdateStaff", con);

            try
            {
                con.Open();
                
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffID);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                sqlCommand.Parameters.AddWithValue("@Salary", salary);
                sqlCommand.Parameters.AddWithValue("@HouseName", address.HouseName);
                sqlCommand.Parameters.AddWithValue("@City", address.City);
                sqlCommand.Parameters.AddWithValue("@State", address.State);
                sqlCommand.Parameters.AddWithValue("@PinCode", address.Pin);
                sqlCommand.Parameters.AddWithValue("@Post", specificData);
                sqlCommand.Parameters.AddWithValue("@ClassAssigned", Convert.ToInt32(specificData));

                if (sqlCommand.ExecuteNonQuery() != 0)
                {
                    return "Staff Updated";
                }
                else
                {
                    return "Staff not found!!";
                }
                

            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                sqlCommand.Dispose();
                con.Close();
            }
        }

        public static string RemoveStaff( int staffID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            SqlCommand sqlCommand = new SqlCommand("Proc_Staff_RemoveStaff", con);

            try
            {
                con.Open();
                         
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffID);

                if (sqlCommand.ExecuteNonQuery() != 0)
                {
                    return "Staff Removed";
                }
                else
                {
                    return "Staff not found!!";
                }

                

            }
            catch (Exception e)
            {
                return e.ToString();
            }
            finally
            {
                sqlCommand.Dispose();
                con.Close();
            }

        }

        public static int GetStaffType(int staffId)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings.Get("connectionString"));
            //Staff staffFound;
            SqlCommand sqlCommand = new SqlCommand("Proc_Staff_GetStaffType", con);

            try
            {
                con.Open();

                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@StaffId", staffId);

                SqlDataReader sqlDataReader;
                sqlDataReader = sqlCommand.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    sqlDataReader.Read();
                    int staffType = Convert.ToInt32(sqlDataReader.GetValue(0));
                    
                    sqlDataReader.Close();
                    return staffType;
                }
                else
                {
                    sqlDataReader.Close();
                    return 3;
                }




            }
            catch (Exception e)
            {
                Console.WriteLine("Sql connection :" + e);
                return 3;
            }

            finally
            {
                sqlCommand.Dispose();
                con.Close();
            }


        }

        private static List<Staff> Populate(SqlDataReader sqlDataReader)
        {
            List<Staff> staffList = new List<Staff>();
            while (sqlDataReader.Read())
            {
                StaffType staffType = (StaffType)Enum.ToObject(typeof(StaffType), sqlDataReader.GetValue(12));
                

                switch (staffType)
                {
                    case StaffType.teachingStaff:
                        TeachingStaff tStaff = new TeachingStaff();

                        PopulateCommonDetails(tStaff);
                        
                        tStaff.Subject = sqlDataReader.GetValue(8).ToString();
                        tStaff.AssignedClass = sqlDataReader.GetValue(9).ToString();
                        staffList.Add(tStaff);
                        break;

                    case StaffType.administrativeStaff:
                        AdminstrativeStaff aStaff = new AdminstrativeStaff();
                        PopulateCommonDetails(aStaff);
                        aStaff.Post = sqlDataReader.GetValue(10).ToString();
                        staffList.Add(aStaff);

                        break;

                    case StaffType.supportStaff:
                        SupportStaff sStaff = new SupportStaff();
                        PopulateCommonDetails(sStaff);
                        sStaff.Post = sqlDataReader.GetValue(11).ToString();
                        staffList.Add(sStaff);

                        break;
                   
                }
                void PopulateCommonDetails(Staff staff)
                {
                    staff.StaffId = Convert.ToInt32(sqlDataReader.GetValue(0));
                    staff.Name = sqlDataReader.GetValue(1).ToString();
                    staff.PhoneNumber = sqlDataReader.GetValue(2).ToString();
                    staff.Salary = Convert.ToInt64(sqlDataReader.GetValue(3));
                    staff.Address.HouseName = sqlDataReader.GetValue(4).ToString();
                    staff.Address.City = sqlDataReader.GetValue(5).ToString();
                    staff.Address.State = sqlDataReader.GetValue(6).ToString();
                    staff.Address.Pin = Convert.ToInt32(sqlDataReader.GetValue(7));
                }

            }
            return staffList;
        }

        



    }
}
