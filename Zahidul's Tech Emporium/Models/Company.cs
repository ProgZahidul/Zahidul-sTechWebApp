using System.ComponentModel.DataAnnotations;

namespace Zahidul_s_Tech_Emporium.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public  string ?PhoneNumber { get; set; }
    }
}
