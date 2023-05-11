using AppSettingsAssignment.Model;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppSettingsAssignment.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IConfiguration _configuration;

        public StudentsService(IConfiguration configuration) 
        {
            this._configuration = configuration;
        }

        public async Task<List<Students>> GetStudentsData()
            {
                List<Students> students = new List<Students>();
                string spName = Constants.getAllStundentsData;

                using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DBContext")))
                {
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    conn.Open();

                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandTimeout = 120;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Students student = new Students
                            {
                                Id = Convert.ToInt32(dr["ID"]),
                                AdmsnNo = Convert.ToInt32(dr["AdmsnNo"]),
                                Name = Convert.ToString(dr["Name"]),
                                Class = Convert.ToInt32(dr["Class"]),
                                Address = Convert.ToString(dr["Address"])
                            };
                            students.Add(student);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }

                    dr.Close();

                    conn.Close();
                }

                return students;
            }

        public async Task<Students> GetStudentsDataById(int id)
        {
            Students student = new Students();
            string spName = Constants.getAllStundentsDataById;

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DBContext")))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);

                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Value = id
                };
                cmd.Parameters.Add(param);

                conn.Open();

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        student = new Students
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            AdmsnNo = Convert.ToInt32(dr["AdmsnNo"]),
                            Name = Convert.ToString(dr["Name"]),
                            Class = Convert.ToInt32(dr["Class"]),
                            Address = Convert.ToString(dr["Address"])
                        };
                    }
                }
                else
                {
                    Console.WriteLine("No data found");
                }

                dr.Close();

                conn.Close();
            }

            return student;
        }
    }
}
