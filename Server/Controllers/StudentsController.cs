using Microsoft.AspNetCore.Mvc;
using IDCARDS.Server.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDCARDS.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly smsdbContext context;

        public StudentsController(smsdbContext context)
        {
            this.context = context;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public List<Student> Get()
        {
            return context.Students.ToList<Student>();
                //new { Items = context.Students, Count = context.Students.Count() };

        }


        // GET: api/<StudentsController>
        [HttpGet]       
        public List<Student> GetDepartment(string Department)
        {
            return context.Students.Where(x=>x.Faculty == Department).ToList<Student>();
            //new { Items = context.Students, Count = context.Students.Count() };

        }

        [HttpGet]
        public List<string> GetDistinctFaculties()
        {
            var query = @"
        SELECT DISTINCT Faculty
        FROM Students
        
    ";

            //var parameter = new SqlParameter("@department", department);

            var faculties = context.Students
                .FromSqlRaw(query)
                .Select(s => s.Faculty)
                .ToList();

            return faculties;
        }



        [HttpGet]

        public List<Student> GetUnSync(int prevVersion)
        {
            return context.Students.Where(x => x.SyncVersion >prevVersion).ToList<Student>();
            //new { Items = context.Students, Count = context.Students.Count() };

        }

       



        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        [HttpPut]
        public async Task<Response> Update( [FromBody] Student student)
        {
            Response result = new Response();
            Student _student = new Student();
            _student = context.Students.Where(x=> x.RegNumber.Equals(student.RegNumber)).FirstOrDefault();

            if(_student != null)
            {
                _student.NfcSn = student.NfcSn;
                _student.IdExpireDate = student.IdExpireDate;
                _student.UpSync = student.UpSync;
                context.Students.Update(_student);
                await context.SaveChangesAsync(true);
                result.Result = "Success";
                return result;
            }
            else
            {
                result.Result = "Faied";
                return result;

            }



        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    public class Response
    {
        public string Result { get; set; }
    }
}
