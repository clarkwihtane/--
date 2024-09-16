using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Employee
    {
        [Key]
        public int employee_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public string email { get; set; }

        public string groups { get; set; }

        public DateTime hire_date { get; set; }

        public int password { get; set; } 

        public int monthly_effort { get; set; } 

        public string employee_activity {  get; set; } 


    }
}
