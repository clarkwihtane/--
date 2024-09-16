using System.ComponentModel.DataAnnotations;

namespace WebApplication9.Models
{
    public class Project
    {

        [Key]
        public int project_id { get; set; }
        public string project_name { get; set; }
        public string inactive_projects { get; set; }

        public DateTime start_date { get; set; }

        public DateTime end_date { get; set; }


    }
}
