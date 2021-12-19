using System;
using System.Data;
using System.Windows;
using System.Data.SqlClient;

namespace FP_Pemrograman.Model
{
    internal class ModelTemplate
    {
        private static SqlConnection connect;
        private SqlCommand command;
        private bool result;

        public static SqlConnection GetConnection()
        {
            connect = new SqlConnection();
            //instance
            connect.ConnectionString = "Data Source = EL-LOBO;" +
                                       "Initial Catalog = ProjectAkhir;" +
                                       "Integrated Security = True";   
            return connect;
        }

        public DataSet Select(string table, string kondisi)
        { 
        DataSet ds = new DataSet();
            try
            {
                connect.Open();
                command = new SqlCommand();
                command.Connection = connect;
                command.CommandType = CommandType.Text;
                if (kondisi == null)
                {
                    command.CommandText = "SELECT * FROM " + table;
                }
                else
                {
                    command.CommandText = "SELECT * FROM " + table + " WHERE " + kondisi; 
                }
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(ds,table);
            }
            catch (SqlException)
            {
                ds = null;
            }
            connect.Close();

            return ds;
        }

        public bool Insert(string table, string data)
        {
            result = false;
            try
            {
                string query = "INSERT INTO " + table + " VALUES (" + data + " )";
                connect.Open();
                command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            { 
            return false;
            }
            connect.Close();
            return result;
        }

        public bool Update(string table, string data, string kondisi)
        { 
        result = false;
            try
            {
                string query = "UPDATE " + table + " SET " + data + " WHERE " + kondisi;
                connect.Open();
                command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;
            }
            catch (SqlException)
            { 
            result = false; 
            }
            connect.Close();
            return result;
        }

        public bool Delete(string table, string kondisi)
        { 
        result = false;
            try
            {
                string query = "SELECT FROM " + table + " WHERE " + kondisi;
                connect.Open();
                command = new SqlCommand();
                command.Connection = connect;
                command.CommandText = query;
                command.ExecuteNonQuery();
                result = true;

            }
            catch (SqlException)
            {
                return false;
            }
            connect.Close();
            return result;
        }
    }

    
}
