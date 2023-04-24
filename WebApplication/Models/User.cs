using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplications.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


    }
}
