using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Employee_Project
    {

        [Key]
        public int e_p_id { get; set; }
        public DateTime effort_date { get; set; }

        public string goals { get; set; }

        public int amount { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }


    }
}
