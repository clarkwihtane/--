using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Effort
    {

        [Key]
        public int effort_id { get; set; }


        public int project_id { get; set; }

        public int employee_id { get; set; }


    }
}
