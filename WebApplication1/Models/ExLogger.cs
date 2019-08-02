using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    internal class SqlConnect
    {
        protected internal void Connection(Exception ex, SqlConnection con)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);
            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("uspErrorLog", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@connectionSource", con.ToString());
                cmd.Parameters.AddWithValue("@message", ex.Message);
                cmd.Parameters.AddWithValue("@stackTrace", ex.StackTrace.ToString());
                cmd.Parameters.AddWithValue("@errorSource", ex.Source.ToString());
                cmd.Parameters.AddWithValue("@targetSite", ex.TargetSite.ToString());
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
    public static class ExLogger
    {
       public static void Logger(Exception exception,SqlConnection con)
        {
            SqlConnect sql = new SqlConnect();
            sql.Connection(exception,con);

        }
        public static void Logger(Exception exception,string dir)
        {
            string message= "---------------------------------------------------------";
            message += string.Format("\nTime : {0}",System.DateTime.Now.ToString());
            message += "---------------------------------------------------------";
            message += Environment.NewLine;
            message+="Exception Message: "+exception.Message+Environment.NewLine;
            message += "Source: " + exception.Source + Environment.NewLine;
            message += "TargerSite: " + exception.TargetSite + Environment.NewLine;
            message += "StackTrace: " + exception.StackTrace;
            message += Environment.NewLine+"---------------------------------------------------------";
            message+="END" + "---------------------------------------------------------";
            message += Environment.NewLine;

            string path = @"D:\ErrorLog.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(dir, true))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
            }
            catch
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(message);
                    sw.Close();
                }
            }
        }

       
    }
}