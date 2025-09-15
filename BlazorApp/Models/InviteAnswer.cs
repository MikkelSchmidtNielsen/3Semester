using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Models
{
    public class InviteAnswer
    {
        [Required(ErrorMessage = "Navn skal udfyldes")]
        [StringLength(50, ErrorMessage = "Navn må ikke være længere end 50 tegn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email skal udfyldes")]
        [EmailAddress(ErrorMessage = "Indtast en gyldig email-adresse")]
        public string Email { get; set; }

        public bool IsComing { get; set; }

        public int Attendants { get; set; }
        public DateTime AnswerTime { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Name} kommer til fødselsdag! - Email: {Email}, Deltagere: {Attendants}";
        }
    }
}
