using AppSettingsAssignment.DataModels;
using AppSettingsAssignment.Model;
using AppSettingsAssignment.Services;
using AppSettingsAssignment.ViewModels.Response;
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
        public async Task<List<StudentResponse>> GetStudentsData()
        {
            List<StudentResponse> result = await studentsService.GetStudentsData();

            return result;
        }

        [HttpGet]
        [Route("student/getstudentsdataef")]
        public async Task<IEnumerable<StudentResponse>> GetStudentsDataEf()
        {
            IEnumerable<StudentResponse> result = await studentsService.GetStudentsDataEf();

            return result;
        }

        [HttpGet]
        [Route("student/getstudentsdatabyid/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetStudentsDataById([FromRoute] int id)
        {
            StudentResponse result = await studentsService.GetStudentsDataById(id);
         
            if (result == null)
            {
                return NoContent();
            }
            else 
            { 
                return Ok(result); 
            }
        }

        [HttpGet]
        [Route("student/getstudentsdatabyidef/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetStudentsDataByIdEf([FromRoute] int id)
        {
            StudentResponse result = await studentsService.GetStudentsDataByIdEf(id);

            if (result == null)
            {
                return NoContent();
            }
            else
            {
                return Ok(result);
            }
        }

        //[HttpPost]
        //[Route("student/createstudent")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //public async Task<IActionResult> CreateStudent([FromBody] int id)
        //{
        //    StudentsDataModel result = await studentsService.GetStudentsDataByIdEf(id);

        //    if (result == null)
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return Ok(result);
        //    }
        //}
    }
}
