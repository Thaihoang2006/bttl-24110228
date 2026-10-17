using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.Data.DAL
{
    public class DataHelper
    {
        private SqlConnection con;
        string connectionString;

        public DataHelper()
        {
            try
            {
                string? cfg = ConfigurationManager.ConnectionStrings["studentDataBase"]?.ConnectionString
                           ?? ConfigurationManager.ConnectionStrings["QLSV"]?.ConnectionString;

                this.connectionString = !string.IsNullOrEmpty(cfg)
                    ? cfg
                    : @"Server=LAPTOP-6SN65NCS\HUECTMDB; Database=QLSV;Integrated Security=True; TrustServerCertificate=true";
            }
            catch
            {
                this.connectionString = @"Server=LAPTOP-6SN65NCS\HUECTMDB; Database=QLSV;Integrated Security=True; TrustServerCertificate=true";
            }

            con = new SqlConnection(connectionString);
        }

        public DataHelper(string connectionString)
        {
            this.connectionString = connectionString;
            con = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void MoKetNoi() => OpenConnection();

        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

        public void DongKetNoi() => CloseConnection();

        public void ExecuteNonQuery(string sqlExcuteQuery)
        {
            try
            {
                OpenConnection();
                using (SqlCommand comand = new SqlCommand(sqlExcuteQuery, con))
                {
                    comand.ExecuteNonQuery();
                }
                CloseConnection();
            }
            catch (Exception exx)
            {
                CloseConnection();
                throw new Exception(exx.Message, exx);
            }
        }

        public void ExcuteNonQuery(string sqlExcuteQuery) => ExecuteNonQuery(sqlExcuteQuery);

        public SqlDataReader ExcuteReader(string sqlSelect)
        {
            try
            {
                OpenConnection();
                SqlCommand comand = new SqlCommand(sqlSelect, con);
                SqlDataReader red = comand.ExecuteReader();
                return red;
            }
            catch (Exception exx)
            {
                CloseConnection();
                throw new Exception(exx.Message, exx);
            }
        }

        public SqlDataReader ExecuteReader(string sqlSelect) => ExcuteReader(sqlSelect);

        public DataTable GetDataTable(string sqlSelect)
        {
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(sqlSelect, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message, exx);
            }
        }
    }
}
