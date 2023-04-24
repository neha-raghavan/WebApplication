namespace WebApplications.Services
{
    public interface IEmpService
    {
        Task<ActionResult<Employee>> CreateEmployee(Employee emp);
        List<Employee> GetEmployees();
        void UpdateEmployee(Employee emp);
        void DeleteEmployee(int Id);
        Employee GetEmployee(int Id);

        Task<ActionResult<User>> UserRegister(User user);
        List<User> GetUser();
    }
}



