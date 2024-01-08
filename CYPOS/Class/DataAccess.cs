using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using cypos.Updates.Forms;

namespace cypos
{
    class DataAccess
    {
        //Data Source=dbs;Initial Catalog=CYPOS;Integrated Security=true
        //public static string _ConnectionString = "Data Source=DESKTOP-RUDSQ84;Initial Catalog=CYPOS; Integrated Security=True;";
        public static string _ConnectionString = Properties.Settings.Default.CYPOSConnectionString;
        //static string _ConnectionString1 = Properties.Settings.Default.CYPOSConnectionString1;
        static SqlConnection _Connection = null;
        public static SqlConnection Connection
        {
            get
            {
                if (_Connection == null || _Connection.ConnectionString.Contains("master;"))
                {
                    _Connection = new SqlConnection(_ConnectionString);
                    _Connection.Open();

                    return _Connection;
                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection = new SqlConnection(_ConnectionString);
                    _Connection.Open();
                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);
            Connection.Close();

            return ds;
        }

        public static DataTable GetDataTable(string sql)
        {
            Console.WriteLine(sql);
            DataSet ds = GetDataSet(sql);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static int ExecuteSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            return cmd.ExecuteNonQuery();
        }

        public static int ExecuteSQLParameters(string sql, SqlParameter[] parameter)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(parameter);
            return cmd.ExecuteNonQuery();
        }
        public static int ExecuteScalarSQLParameters(string sql, SqlParameter[] parameter)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            cmd.Parameters.AddRange(parameter);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
        public static int ExecuteScalarSQL(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, Connection);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static int RecordExits(string strTable,string strField, string strValue)
        {
            string strSQL = "SELECT COUNT(*)  FROM " + strTable + " WHERE " + strField + "='" + strValue + "'";

            SqlCommand cmd = new SqlCommand(strSQL, Connection);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

    }

}
