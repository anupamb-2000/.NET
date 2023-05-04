using Microsoft.AspNetCore.Mvc;

namespace AppSettingsAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private IConfiguration _configuration;
        public StudentController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetStudentNames()
        {
            //var list = new List<string>();
            var names = _configuration.GetSection("StudentNames").Get<List<string>>();
            //foreach (var name in names)
            //{
            //    list.Add(name);
            //}
            return Ok(names);
        }
    }
}
