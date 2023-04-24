using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using WebApplications.Models;
using WebApplications.Services;


namespace WebApplications.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EmployeeController : ControllerBase
    {
        public static User user= new User();
        private readonly IEmpService _EmpService;

        private readonly IConfiguration _configuration;
        public EmployeeController(IEmpService EmpService, IConfiguration configuration)
        {
            _EmpService = EmpService;

            _configuration = configuration;
        }

        [HttpGet]

        public IEnumerable<Employee> GetEmployees()
        {
            return _EmpService.GetEmployees();
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee Empitem)
        {
            _EmpService.CreateEmployee(Empitem);
            return Ok();

        }

        [HttpPost]

        public IActionResult UpdateEmployee([FromBody] Employee Empitem)
        {
            // var employee = _EmpService.GetEmployee (id);
            //if (employee != null)
            //{
            _EmpService.UpdateEmployee(Empitem);
            return Ok();
            //}
            //  return NotFound($"Employee Not Found with ID : {employee.EmployeeID}");
        }
        [HttpDelete]

        public IActionResult DeleteEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var existingEmp = _EmpService.GetEmployee(id);
            if (existingEmp != null)
            {
                _EmpService.DeleteEmployee(existingEmp.EmployeeID);
                return Ok();
            }
            return NotFound($"Employee Not Found with ID : {existingEmp.EmployeeID}");
        }

        [HttpGet]

        public IActionResult GetEmployee(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var emp = _EmpService.GetEmployee(id);

            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        //[HttpPost]
        //public IActionResult Register([FromBody] User user)
        //{
        //    _EmpService.UserRegister(user);
        //    return Ok();

        //}
        [HttpGet]

        public IEnumerable<User> GetUser()
        {
            return _EmpService.GetUser();
        }

        [HttpPost]

        public ActionResult<User> Register(User request)
        {
            string PasswordHash=BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserName=request.UserName;
            user.First_Name=request.First_Name;
            user.Last_Name=request.Last_Name;
            user.Email=request.Email;
            user.Role=request.Role;
            user.Password=PasswordHash;

            

            return Ok(user);
        }


    }
}

    //public IActionResult Login(UserLogin users)
    //{

    //    var token = _jwttokenservice.Authenticate(users);

    //    if (token == null)
    //    {
    //        return Ok(new { Message = "Unauthorized" });
    //    }

    //    return Ok(token);




    //}








    //[AllowAnonymous]
    //    [HttpPost]
    //    [Route("Authenticate")]
        //public IActionResult Authenticate(UserLogin users)
        //{
        //    var token = _jwttokenservice.Authenticate(users);

        //    if (token == null)
        //    {
        //        return Ok(new { Message = "Unauthorized" });
        //    }

        //    return Ok(token);
        //}
        
    

