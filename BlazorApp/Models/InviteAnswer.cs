using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class InviteAnswer
    {
        [Required]
        [StringLength(50, ErrorMessage = "Navn må ikke være længere end 50 tegn")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsComing { get; set; }

        [Required]
        public int Attendants { get; set; }
        public DateTime AnswerTime { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Name} kommer til fødselsdag! - Email: {Email}, Deltagere: {Attendants}";
        }
    }
}
