using System.ComponentModel.DataAnnotations;

namespace Interview_Schedule_Management.Models
{
    public class Candidate
    {
        [Key]
        public int C_ID { get; set; }

        public string C_FNAME { get; set; }

        public string C_LNAME { get; set; }

        public string C_DOB { get; set; }

        public string C_GENDER { get; set; }

        public string C_PHONE { get; set; }

        public string C_EMAIL { get; set; }

        public string C_PASSWORD { get; set; }

        public string C_TYPE { get; set; }

        public string C_AGENT_ID { get; set; }
    }
}
