using AppSettingsAssignment.Model;
using Microsoft.Extensions.Configuration;
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

        public async Task<List<Students>> GetStudentsDataSp()
            {
                //var list = new List<string>();
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
        }
}
