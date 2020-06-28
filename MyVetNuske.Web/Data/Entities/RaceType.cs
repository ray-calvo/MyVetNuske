using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVetNuske.Web.Data.Entities
{
    public class RaceType
    {
        public int Id { get; set; }

        [Display(Name = "Razas")]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        public ICollection<Pet> Pets { get; set; }


    }
}
