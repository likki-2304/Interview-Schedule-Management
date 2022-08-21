using System.ComponentModel.DataAnnotations;

namespace Interview_Schedule_Management.Models
{
    public class Admin
    {
        [Key]
        public int AD_ID { get; set; }

        [Required]
        public string AD_Username { get; set; }

        [Required]
        public string AD_Password { get; set; }

        [Required]
        public string AD_Department { get; set; }
    }
}
