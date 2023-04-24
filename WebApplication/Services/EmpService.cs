
namespace WebApplications.Services
{
    public class EmpService:IEmpService
    {
            public EmpContext _empDbContext;
            
            public EmpService(EmpContext EmpDbContext)
            {
                _empDbContext = EmpDbContext;
            }
            public async Task<ActionResult<Employee>>  CreateEmployee([FromBody] Employee EmpItem)
            {
                _empDbContext.Employee.Add(EmpItem);
                 await _empDbContext.SaveChangesAsync();
                return EmpItem;
                
            }
            public List<Employee> GetEmployees()
            {
                return _empDbContext.Employee.ToList();
            }
        [HttpPut]
        public void UpdateEmployee( Employee Empitem)
        {
            
                _empDbContext.Employee.Update(Empitem);
                _empDbContext.SaveChanges();
            
        }
            public void DeleteEmployee(int Id)
            {
                var employee = _empDbContext.Employee.FirstOrDefault(x => x.EmployeeID == Id);
                if (employee != null)
                {
                    _empDbContext.Remove(employee);
                    _empDbContext.SaveChanges();
                }
            }

            public Employee GetEmployee(int Id)
            {
                return _empDbContext.Employee.FirstOrDefault(x => x.EmployeeID == Id);
            }
            public async Task<ActionResult<User>> UserRegister([FromBody] User user)
            {
                    _empDbContext.User.Add(user);
                await _empDbContext.SaveChangesAsync();
                return user;
             }
        public List<User> GetUser()
        {
            return _empDbContext.User.ToList();
        }
    }
    }
