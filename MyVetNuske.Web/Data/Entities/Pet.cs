using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyVetNuske.Web.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Imagen")]
        public string ImageUrl { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Born { get; set; }

        [Display(Name = "Comentarios")]
        public string Remarks { get; set; }

        
        public string ImageFullPath => string.IsNullOrEmpty(ImageUrl)
            ? null
            : $"https://myvetnuske.azurewebsites.net{ImageUrl.Substring(1)}";

        [Display(Name = "Fecha Nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime BornLocal => Born.ToLocalTime();

        [Display(Name = "Especie")]
        public PetType PetType { get; set; }

        [Display(Name = "Raza")]
        public RaceType RaceType { get; set; }

        [Display(Name = "Propietario")]
        public Owner Owner { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<Agenda> Agendas { get; set; }



    }
}
