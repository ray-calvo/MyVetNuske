using System;
using System.Collections.Generic;

namespace MyVetNuske.Common.Models
{
    public class PetResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string RaceType { get; set; }

        public DateTime Born { get; set; }

        public string Remarks { get; set; }

        public string PetType { get; set; }

        public ICollection<HistoryResponse> Histories { get; set; }
    }

}
