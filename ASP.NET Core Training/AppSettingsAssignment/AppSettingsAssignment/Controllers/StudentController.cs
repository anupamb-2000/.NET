using AppSettingsAssignment.Model;
using AppSettingsAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data.SqlClient;

namespace AppSettingsAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private IConfiguration _configuration;
        private readonly IStudentsService studentsService;

        public StudentController(IConfiguration configuration, IStudentsService studentsService) 
        {
            _configuration = configuration;
            this.studentsService = studentsService;
        }

        [HttpGet]
        [Route("student/getstudentnames")]
        public IActionResult GetStudentNames()
        {
            //var list = new List<string>();
            var student = new StudentNames();
            _configuration.GetSection("Student").Bind(student);
            //foreach (var name in names)
            //{
            //    list.Add(name);
            //}
            return Ok(student.Names);
        }

        [HttpGet]
        [Route("student/getstudentsdatasp")]
        public async Task<List<Students>> GetStudentsDataSp()
        {
            List<Students> result = await studentsService.GetStudentsDataSp();

            return result;
        }
    }
}
