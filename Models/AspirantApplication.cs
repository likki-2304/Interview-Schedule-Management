using System.ComponentModel.DataAnnotations;

namespace Interview_Schedule_Management.Models
{
    public class AspirantApplication
    {
        [Key]
        public int APP_ID { get; set; }

        //public int APP_JOB_ID { get; set; }

        public string APP_NAME { get; set; }

        public int APP_C_ID { get; set; }

        public int APP_EXP { get; set; }

        public int APP_REFF_ID { get; set; }

        public string APP_QUALI { get; set; }

        public string APP_INT_TYPE { get; set; }

        public bool INT_STAT { get; set; }

        public bool INT_HR_MARKS { get; set; }

        //public int INT_MARKS { get; set; }

        //public string CANDIDATURE_STATUS { get; set; }

        //public string INT_RESULT { get; set; }
    }
}
