using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApplication1.Models.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SqlConnection con = null;
        private SqlCommand cmd = null;
        private SqlDataReader reader;

        public EmployeeRepository()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["Db"].ConnectionString);

        }


        public bool Delete(Employee employee)
        {

            using (con)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("uspDeleteTemptble", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@id", employee.Id);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    ExLogger.Logger(ex, con);
                }
            }
            return false;
        }

        public List<Employee> GetAllData()
        {
            using (con)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("uspGetAllDataTemptble", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    reader = cmd.ExecuteReader();
                    List<Employee> employees = new List<Employee>();
                    while (reader.Read())
                    {
                        employees.Add(new Employee
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Date = Convert.ToDateTime(reader["date"]),
                            Name = Convert.ToString(reader["name"]),
                            Salary = Convert.ToDecimal(reader["salary"]),
                            CalculatedSalary = Convert.ToDecimal(GetSafeValue(reader["calculatedSalary"])),
                            YearsInAdapty = Convert.ToDouble(GetSafeValue(reader["yearsInAdapty"]))


                        });
                    };
                    return employees;
                }
                catch (Exception ex)
                {
                    ExLogger.Logger(ex, con);
                    return null;
                }
            }
        }

        public bool Save(Employee employee)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("uspInsertTemptble", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@yearsInAdapty", employee.YearsInAdapty);

                    cmd.ExecuteNonQuery();

                    return true;
                }
                catch (Exception ex)
                {
                    ExLogger.Logger(ex, con);
                }
                //cannot write return false; in finally block because finally block cannot have return
            }
            return false;
        }



        public bool Update(Employee employee)
        {
            using (con)
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("uspUpdateTemptble", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@id", employee.Id);
                    cmd.Parameters.AddWithValue("@name", employee.Name);
                    cmd.Parameters.AddWithValue("@salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@yearsInAdapty", employee.YearsInAdapty);

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    ExLogger.Logger(ex, con);
                }
            }
            return false;

        }

        public static object GetSafeValue(object value)
        {
            if (DBNull.Value==value)
            {
                return 0;
            }
            return value;
        }

    }



}