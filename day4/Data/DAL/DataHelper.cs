using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.Data.DAL
{
    
    public class DataHelper
    {
        
        public SqlConnection con;

        
        public DataHelper(string strcon)
        {
            con = new SqlConnection(strcon);
        }

        
        public string MoKetNoi()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        
        public void DongKetNoi()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            catch
            {
            }
        }

        
        public void ExcuteNonQuery(string sqlString)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                throw new InvalidOperationException($"Lỗi kết nối CSDL: {err}");
            }

            try
            {
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    cm.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        
        public int ExecuteNonQuery(string sqlString)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                throw new InvalidOperationException($"Lỗii kết nối CSDL: {err}");
            }

            try
            {
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    return cm.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        
        public int ExecuteNonQuery(string sqlString, SqlParameter[] parameters)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                throw new InvalidOperationException($"Lỗi kết nối CSDL: {err}");
            }

            try
            {
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    if (parameters != null && parameters.Length > 0)
                    {
                        cm.Parameters.AddRange(parameters);
                    }
                    return cm.ExecuteNonQuery();
                }
            }
            finally
            {
                DongKetNoi();
            }
        }

        
        public SqlDataReader? ExcuteReader(string sqlString)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                return null;
            }

            try
            {
                SqlCommand cm = new SqlCommand(sqlString, con);
                return cm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                DongKetNoi();
                return null;
            }
        }

        
        public SqlDataReader? ExecuteReader(string sqlString)
        {
            return ExcuteReader(sqlString);
        }

        
        public SqlDataReader? ExcuteReader(string sqlString, SqlParameter[] parameters)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                return null;
            }

            try
            {
                SqlCommand cm = new SqlCommand(sqlString, con);
                if (parameters != null && parameters.Length > 0)
                {
                    cm.Parameters.AddRange(parameters);
                }
                return cm.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                DongKetNoi();
                return null;
            }
        }

        
        public object? ExcuteScalar(string sqlString)
        {
            string err = MoKetNoi();
            if (!string.IsNullOrEmpty(err))
            {
                return null;
            }

            try
            {
                using (SqlCommand cm = new SqlCommand(sqlString, con))
                {
                    return cm.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                DongKetNoi();
            }
        }

        public object? ExecuteScalar(string sqlString) => ExcuteScalar(sqlString);
    }
}
