using AppSettingsAssignment.Model;
using AppSettingsAssignment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Net;

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
            var student = new StudentNames();
            _configuration.GetSection("Student").Bind(student);
            return Ok(student.Names);
        }

        [HttpGet]
        [Route("student/getstudentsdata")]
        public async Task<List<Students>> GetStudentsData()
        {
            List<Students> result = await studentsService.GetStudentsData();

            return result;
        }

        [HttpGet]
        [Route("student/getstudentsdatabyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetStudentsDataById([FromRoute] int id)
        {
            Students result = await studentsService.GetStudentsDataById(id);
         
            if (result.Id == -1)
            {
                return NoContent();
            }
            else 
            { 
                return Ok(result); 
            }
        }
    }
}
