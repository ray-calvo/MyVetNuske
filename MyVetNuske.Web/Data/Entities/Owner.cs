using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace MyVetNuske.Web.Data.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]

        [Display(Name = "Nombres")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]

        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Telefono Fijo")]
        public string FixedPhone { get; set; }
        [Required]
        [MaxLength(12, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Telefono Celular")]
        public string CellPhone { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Display(Name = "Direccion")]
        public string Address { get; set; }
        [Display(Name = "Propietario")]
        public string FullName => $"{FirstName} {LastName}";

        public ICollection<Pet> Pets { get; set; }
        public ICollection<Agenda> Agendas { get; set; }



    }
}
