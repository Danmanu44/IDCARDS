using Microsoft.AspNetCore.Mvc;
using IDCARDS.Server.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IDCARDS.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly smsdbContext context;

        public StaffController(smsdbContext context)
        {
            this.context = context;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public List<Staff> Get()
        {
            return context.Staff.ToList<Staff>();
                //new { Items = context.Students, Count = context.Students.Count() };

        }


        // GET: api/<StudentsController>
        [HttpGet]       
        public List<Staff> GetDepartment(string Department)
        {
            return context.Staff.Where(x=>x.Department == Department).ToList<Staff>();
            //new { Items = context.Staffs, Count = context.Staffs.Count() };

        }
        [HttpGet]

        public List<Staff> GetUnSync(int prevVersion)
        {
            return context.Staff.Where(x => x.SyncVersion >prevVersion).ToList<Staff>();
            //new { Items = context.Staffs, Count = context.Staffs.Count() };

        }

        public List<Staff> GetStaff(string PsnNumber)
        {
            return context.Staff.Where(x => x.PsnNumber == PsnNumber).ToList<Staff>();
            //new { Items = context.Staffs, Count = context.Staffs.Count() };

        }

        public List<Staff> GetAllStaff()
        {
            return context.Staff.ToList<Staff>();
            //new { Items = context.Staffs, Count = context.Staffs.Count() };

        }



        // POST api/<StaffsController>
        [HttpPost]
        public void Post([FromBody] Staff Staff)
        {
            context.Staff.Add(Staff);
            context.SaveChanges();
        }

        // PUT api/<StaffsController>/5
        [HttpPut]
        public async Task<Response> Update( [FromBody] Staff Staff)
        {
            Response result = new Response();
            Staff _Staff = new Staff();
            _Staff = context.Staff.Where(x=> x.PsnNumber.Equals(Staff.PsnNumber)).FirstOrDefault();

            if(_Staff != null)
            {
                _Staff.NfcSn = Staff.NfcSn;
                _Staff.Designation = Staff.Designation;
                _Staff.Department = Staff.Department;
                context.Staff.Update(_Staff);
                await context.SaveChangesAsync(true);
                result.Result = "Success";
                return result;
            }
            else
            {
                result.Result = "Failed";
                return result;

            }



        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
   
}
