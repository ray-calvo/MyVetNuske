using System.ComponentModel.DataAnnotations;

namespace MyVetNuske.Common.Models
{
    public class EmailRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
