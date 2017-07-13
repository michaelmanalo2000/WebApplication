using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBLL
{
    class DBConnection
    {
        private string _connectionStr;

        public DBConnection(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public System.Data.SqlClient.SqlConnection ConnectToSql()
        {
            System.Data.SqlClient.SqlConnection conn =
                new System.Data.SqlClient.SqlConnection();

            conn.ConnectionString = _connectionStr;

            try
            {
                conn.Open();

                return conn;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int GetCounter()
        {
            var conn = ConnectToSql();
            SqlCommand myCMD = new SqlCommand("SELECT TOP 1 CurrentCounter FROM CounterTable", conn);
            SqlDataReader myReader = myCMD.ExecuteReader();
            try
            {
                if (myReader.Read())
                    return myReader.GetInt32(0);
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myReader.Close();
                conn.Close();
            }

        }

        public int UpdateCurrentCounter(int ctr)
        {
            var conn = ConnectToSql();
            SqlCommand myCMD = new SqlCommand("UPDATE CounterTable  SET CurrentCounter = " + ctr + " WHERE ID = 1", conn);

            try
            {
                return myCMD.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
