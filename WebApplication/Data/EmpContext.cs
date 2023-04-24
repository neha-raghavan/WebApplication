

using WebApplications.Models;

namespace WebApplications.Data
{
    public class EmpContext :  DbContext
    {

        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public EmpContext(DbContextOptions<EmpContext> options) : base(options) { }

        


    }   }








  
       


    
