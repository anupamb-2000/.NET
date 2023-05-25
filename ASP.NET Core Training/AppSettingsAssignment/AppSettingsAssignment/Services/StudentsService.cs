using AppSettingsAssignment.DataModels;
using AppSettingsAssignment.ViewModels.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace AppSettingsAssignment.Services
{
    public class StudentsService : DomainService, IStudentsService
    {
        private readonly IConfiguration _configuration;
        private readonly StudentsDBContext studentsDBContext;

        public StudentsService(IMapper mapper, IConfiguration configuration, StudentsDBContext studentsDBContext) : base(mapper)
        {
            this._configuration = configuration;
            this.studentsDBContext = studentsDBContext;
        }

        public async Task<List<StudentResponse>> GetStudentsData()
        {
            List<StudentsDataModel> students = new List<StudentsDataModel>();
            string spName = Constants.getAllStundentsData;

            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DBContext")))
            {
                SqlCommand cmd = new SqlCommand(spName, conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 120;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    StudentsDataModel obj = new StudentsDataModel();
                    obj.Id = int.Parse(dt.Rows[i]["Id"].ToString());
                    obj.AdmsnNo = int.Parse(dt.Rows[i]["AdmsnNo"].ToString());
                    obj.Name = dt.Rows[i]["Name"].ToString();
                    obj.Class = int.Parse(dt.Rows[i]["Class"].ToString());
                    obj.Address = dt.Rows[i]["Address"].ToString();

                    students.Add(obj);
                }

            }
                return Mapper.Map<List<StudentResponse>>(students);
        }

        public async Task<IEnumerable<StudentResponse>> GetStudentsDataEf()
        {
            var students = await studentsDBContext.Students.Select(s => s).ToListAsync();
            return Mapper.Map<IEnumerable<StudentResponse>>(students);
        }

        public async Task<StudentResponse> GetStudentsDataById(int id)
        {
            StudentsDataModel student = null;
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
                        student = new StudentsDataModel
                        {
                            Id = Convert.ToInt32(dr["ID"]),
                            AdmsnNo = Convert.ToInt32(dr["AdmsnNo"]),
                            Name = Convert.ToString(dr["Name"]),
                            Class = Convert.ToInt32(dr["Class"]),
                            Address = Convert.ToString(dr["Address"])
                        };
                    }
                }

                dr.Close();

                conn.Close();
            }

            return Mapper.Map<StudentResponse>(student);
        }

        public async Task<StudentResponse> GetStudentsDataByIdEf(int id)
        {
            StudentsDataModel student = await studentsDBContext.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
            return Mapper.Map<StudentResponse>(student);
        }
    }
}
