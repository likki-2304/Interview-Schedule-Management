using System.ComponentModel.DataAnnotations;

namespace Interview_Schedule_Management.Models
{
    public class Job
    {
        [Key]
        public int JOB_ID { get; set; }

        public int HR_ID { get; set; }

        public string REQ_ID { get; set; }

        public string COMPANY_NAME { get; set; }

        public int REQ_VAC { get; set; }

        public int REQ_EXP { get; set; }

        public string DOMAIN { get; set; }

        public string CLOSING_DATE { get; set; }

        public string PRIORITY { get; set; }

        public string INT_TYPE { get; set; }
    }
}
